using SolutionsPG.QuickSilver.Core.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using SolutionsPG.QuickSilver.Core.Exceptions;

namespace SolutionsPG.QuickSilver.Core.System
{
    public class ServiceLocator : IServiceLocator
    {
        #region | Properties |

        private IServiceLocator _default;
        public IServiceLocator Default => _default ?? (_default = new ServiceLocator());

        private IDictionary<Type, Delegate> _resolversByType;
        private IDictionary<Type, Delegate> ResolversByType => _resolversByType ?? (_resolversByType = new Dictionary<Type, Delegate>());

        #endregion //Properties

        #region | IServiceLocationRegisterer |

        public IServiceLocator Register<T>() => Register_<T, T>();
        public IServiceLocator Register<T>(Func<T> resolver) => this.AddResolver(resolver.ThrowIfArgumentNull(nameof(resolver)));
        public IServiceLocator Register<TBase, TConcrete>() where TConcrete : TBase => this.Register_<TBase, TConcrete>();
        public IServiceLocator Register<TBase, TDerived>(Func<TDerived> resolver) where TDerived : TBase
        {
            resolver.ThrowIfArgumentNull(nameof(resolver));

            if (resolver.TryCastAs<Func<TBase>>(out var castedResolver) == false)
                throw new ArgumentException("Could not use the resolver as expected", nameof(resolver));
            return this.AddResolver(castedResolver);
        }

        private ServiceLocator Register_<TBase, TConcrete>() where TConcrete : TBase
        {
            var concreteType = TypeCache<TConcrete>.Type;
            if (this.TryGetResolver<TConcrete>(concreteType, out var concreteResolver) == false)
            {
                concreteResolver = this.CreateResolver<TConcrete>(concreteType);
                this.AddResolver(concreteResolver);
            }

            if (TypeCache<TBase>.Type.IsNot(concreteType))
            {
                concreteResolver.TryCastAs(out Func<TBase> baseResolver);
                this.AddResolver(baseResolver);
            }

            return this;
        }

        private ServiceLocator Register_(Type type) => this.AddResolver(type, CreateResolver<object>(type));

        private Func<TReturn> CreateResolver<TReturn>(Type type)
        {
            type.ThrowIf(type.IsInterface || type.IsAbstract,
                    t => new ApplicationException($"Can't create resolver, type is not concrete: {type}"))
                .ThrowIf(TryGetConstructor(type, out var selectedConstructor) == false,
                    t => new ApplicationException($"Could not get constructor for type {type}"));

            var parameterTypes = selectedConstructor.GetParameters().Select(p => p.ParameterType).ToArray();

            return () =>
            {
                var resolvedParameters = parameterTypes.Select(this.Resolve_).ToArray();
                return (TReturn) selectedConstructor.Invoke(resolvedParameters);
            };
        }

        private ServiceLocator AddResolver<T>(Func<T> resolver) => this.AddResolver(TypeCache<T>.Type, resolver);
        private ServiceLocator AddResolver(Type type, Delegate resolver) { this.ResolversByType.Add(type, resolver); return this; }

        #endregion //IServiceLocationRegisterer

        public T Resolve<T>() => Resolve_(TypeCache<T>.Type, () => this.Register<T>().Resolve<T>());
        private object Resolve_(Type type) => Resolve_(type, () => this.Register_(type).Resolve_(type));
        private TResult Resolve_<TResult>(Type type, Func<TResult> registerAndResolve) => this.TryGetResolver(type, out Func<TResult> resolver) ? resolver() : registerAndResolve();

        private bool TryGetResolver<T>(Type type, out Func<T> resolver)
        {
            if (this.ResolversByType.TryGetValue(type, out var resolverDelegate))
            {
                resolver = resolverDelegate as Func<T>;
                if (resolver == null)
                    resolverDelegate.TryCastAs(out resolver);
            }
            else
            {
                resolver = null;
            }

            return resolver != null;
        }

        private static bool TryGetConstructor(Type type, out ConstructorInfo constructorInfo)
        {
            var constructors = type.GetConstructors();
            var constructorsLength = constructors?.Length ?? 0;
            if (constructorsLength > 0)
            {
                constructorInfo = constructorsLength > 1 ? constructors.FirstOrDefault(c => c.GetParameters().Length == 0) : constructors[0];
            }
            else
            {
                constructorInfo = null;
            }

            return constructorInfo != null;
        }
    }
}
