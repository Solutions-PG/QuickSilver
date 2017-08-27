using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace SolutionsPG.QuickSilver.Core.System
{
    public static class FastActivator<TResult>
    {
        public static readonly Func<TResult> CreateInstance = FastConstructorGenerator.Generate<TResult>();
        public static Func<object[], object> GetConstructor(IEnumerable<Type> arguments)
        {
            return GetConstructor(arguments.ToArray());
        }
        public static Func<object[], object> GetConstructor(params Type[] arguments)
        {
            var constructorInfo = TypeCache<TResult>.Type.GetConstructor(arguments);
            return (constructorInfo != null) ? constructorInfo.Invoke : (Func<object[], object>)null; ;
        }
    }

    public static class FastActivator<T, TResult>
    {
        public static readonly Func<T, TResult> CreateInstance = FastConstructorGenerator.Generate<T, TResult>();
    }

    public static class FastActivator<T1, T2, TResult>
    {
        public static readonly Func<T1, T2, TResult> CreateInstance = FastConstructorGenerator.Generate<T1, T2, TResult>();
    }

    public static class FastActivator<T1, T2, T3, TResult>
    {
        public static readonly Func<T1, T2, T3, TResult> CreateInstance = FastConstructorGenerator.Generate<T1, T2, T3, TResult>();
    }

    internal static class FastConstructorGenerator
    {
        private static readonly Random Random = new Random();
        private const bool SkipVisibility = true;
        private const string MethodNameSuffix = "_GeneratedByFastConstructor";

        public static Func<TResult> Generate<TResult>()
        {
            return (Func<TResult>)Generate_(TypeCache<TResult>.Type, TypeCache<Func<TResult>>.Type);
        }

        public static Func<T, TResult> Generate<T, TResult>()
        {
            return (Func<T, TResult>)Generate_(TypeCache<TResult>.Type, TypeCache<Func<T, TResult>>.Type, TypeCache<T>.Type);
        }

        public static Func<T1, T2, TResult> Generate<T1, T2, TResult>()
        {
            return (Func<T1, T2, TResult>)Generate_(TypeCache<TResult>.Type, TypeCache<Func<T1, T2, TResult>>.Type, TypeCache<T1>.Type, TypeCache<T2>.Type);
        }

        public static Func<T1, T2, T3, TResult> Generate<T1, T2, T3, TResult>()
        {
            return (Func<T1, T2, T3, TResult>)Generate_(TypeCache<TResult>.Type, TypeCache<Func<T1, T2, T3, TResult>>.Type, TypeCache<T1>.Type, TypeCache<T2>.Type, TypeCache<T3>.Type);
        }

        private static Delegate Generate_(Type constructorType, Type delegateType, params Type[] parameterTypes)
        {
            var constructorInfo = constructorType.GetConstructor(parameterTypes);
            if (constructorInfo == null && (constructorType.IsValueType == false || parameterTypes.Length > 0))
            {
                return null;
            }
            //-----

            var methodInfo = new DynamicMethod(constructorType.Name + Random.Next() + MethodNameSuffix,
                constructorType, parameterTypes, constructorType.Module, SkipVisibility);

            ILGenerator ilGenerator = methodInfo.GetILGenerator();
            if (constructorInfo != null)
            {
                ilGenerator.EmitArgs(parameterTypes.Length);
                ilGenerator.Emit(OpCodes.Newobj, constructorInfo);
            }
            else
            {
                // Constructor for value types could be null
                var builder = ilGenerator.DeclareLocal(constructorType);
                ilGenerator.Emit(OpCodes.Ldloca, builder);
                ilGenerator.Emit(OpCodes.Initobj, constructorType);
                ilGenerator.Emit(OpCodes.Ldloc, builder);
            }
            ilGenerator.Emit(OpCodes.Ret);

            return methodInfo.CreateDelegate(delegateType);
        }

        private static void EmitArgs(this ILGenerator ilGenerator, int nbArgs)
        {
            if (nbArgs >= 1)
            {
                ilGenerator.Emit(OpCodes.Ldarg_0);
                if (nbArgs >= 2)
                {
                    ilGenerator.Emit(OpCodes.Ldarg_1);
                    if (nbArgs >= 3)
                    {
                        ilGenerator.Emit(OpCodes.Ldarg_2);
                        if (nbArgs >= 4)
                        {
                            ilGenerator.Emit(OpCodes.Ldarg_3);

                            nbArgs -= 4;
                            for (byte i = 4; nbArgs > 0; --nbArgs, ++i)
                            {
                                ilGenerator.Emit(OpCodes.Ldarg_S, i);
                            }
                        }
                    }
                }
            }
        }
    }
}
