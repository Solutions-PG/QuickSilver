using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SolutionsPG.QuickSilver.Core.Exceptions;
using SolutionsPG.QuickSilver.Core.Experimental.Exceptions;

namespace SolutionsPG.QuickSilver.Core.System.ServiceLocation
{
    public class IoCContainer : IServiceLocator<IoCContainer>, IServiceLocator
    {
        private static readonly object DefaultLock = new object();
        private static volatile IServiceLocator _default;
        public static IServiceLocator Default
        {
            get
            {
                var defaultValue = _default;
                if (defaultValue == null)
                {
                    lock (DefaultLock)
                    {
                        defaultValue = _default;
                        if (defaultValue == null)
                        {
                            defaultValue = new IoCContainer();
                            _default = defaultValue;
                        }
                    }
                }

                return defaultValue;
            }
        }

        private Dictionary<Type, Func<object>> RegisteredProvidersByType { get; } = new Dictionary<Type, Func<object>>();
        private HashSet<Type> LoadedConfiguration { get; } = new HashSet<Type>();

        public T Resolve<T>()
        {
            return (T)Resolve(TypeCache<T>.Type);
        }

        private object Resolve(Type typeOfT)
        {
            if (RegisteredProvidersByType.TryGetValue(typeOfT, out var provider) == false)
            {
                ValidateConcreteType(typeOfT);
                provider = CreateDefaultProvider(typeOfT);
                RegisteredProvidersByType.Add(typeOfT, provider);
            }

            return provider();
        }

        public bool IsRegistered<T>()
        {
            return RegisteredProvidersByType.ContainsKey(TypeCache<T>.Type);
        }

        public IoCContainer Register<TBase, TConcrete>() where TConcrete : TBase
        {
            if (IsRegistered<TBase>())
            {
                throw new InvalidOperationException("Type already registered");
            }
            ValidateTypeAndRegisterDefaultProvider<TBase>(TypeCache<TConcrete>.Type);
            return this;
        }

        private Func<object> ValidateTypeAndRegisterDefaultProvider<TBase>(Type concreteType)
        {
            ValidateConcreteType(concreteType);
            return RegisterDefaultProvider<TBase>(concreteType);
        }

        private void ValidateConcreteType(Type concreteType)
        {
            concreteType.ThrowIf(concreteType.IsInterface,
                    (_, t) => new InvalidOperationException(
                        $"Can't resolve unregistered interface of type {t.AssemblyQualifiedName}"))
                .ThrowIf(concreteType.IsAbstract,
                    (_, t) => new InvalidOperationException(
                        $"Can't resolve unregistered abstract class of type {t.AssemblyQualifiedName}"));
        }

        private Func<object> RegisterDefaultProvider<TBase>(Type concreteType)
        {
            var provider = CreateDefaultProvider(concreteType);
            RegisterProviderByType<TBase>(provider);
            return provider;
        }

        private Func<object> CreateDefaultProvider(Type type)
        {
            //Detect circular dependancy Ex A(B) B(C) C(A)

            var constructor = GetConstructor(type);
            var parameterTypes = constructor.GetParameters().Select(p => p.ParameterType).ToArray();

            return () =>
            {
                var instanciatedParameter = parameterTypes.Select(Resolve).ToArray();
                return constructor.Invoke(instanciatedParameter);
            };
        }

        private static ConstructorInfo GetConstructor(Type type)
        {
            var constructors = type.GetConstructors().ThrowIf(cs => cs.Length == 0, cs => new InvalidOperationException());

            var constructorsWithMostParameters = new List<ConstructorInfo>();
            int previousMax = -1;
            foreach (var constructor in constructors)
            {
                var parametersLength = constructor.GetParameters().Length;
                if (parametersLength >= previousMax)
                {
                    if (parametersLength > previousMax)
                    {
                        constructorsWithMostParameters.Clear();
                        previousMax = parametersLength;
                    }
                    constructorsWithMostParameters.Add(constructor);
                }
            }

            constructorsWithMostParameters.ThrowIf(cs => cs.Count > 1, cs => new InvalidOperationException());

            return constructorsWithMostParameters[0];
        }

        private void RegisterProviderByType<TBase>(Func<object> provider)
        {
            RegisteredProvidersByType.Add(TypeCache<TBase>.Type, provider);
        }

        public IoCContainer Register<TBase, TDerived>(Func<TDerived> provider) where TDerived : TBase
        {
            provider.ThrowIfArgumentNull(nameof(provider));

            if (IsRegistered<TBase>())
            {
                throw new InvalidOperationException("Type already registered");
            }

            RegisterProviderByType<TBase>(() => provider());
            return this;
        }

        public IoCContainer Configure<TConfig>() where TConfig : ConfigurationBase, new()
        {
            if (LoadedConfiguration.Add(TypeCache<TConfig>.Type))
                Activator.CreateInstance<TConfig>().Configure(this);
            return this;
        }

        IServiceLocator IServiceLocationRegisterer<IServiceLocator>.Register<TBase, TConcrete>() => Register<TBase, TConcrete>();
        IServiceLocator IServiceLocationRegisterer<IServiceLocator>.Register<TBase, TDerived>(Func<TDerived> provider) => Register<TBase, TDerived>(provider);
        IServiceLocator IServiceLocationRegisterer<IServiceLocator>.Configure<TConfig>() => Configure<TConfig>();
    }
}
