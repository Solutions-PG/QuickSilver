using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;

namespace SolutionsPG.QuickSilver.Core.System
{
    public static class FastActivator<T> where T : new()
    {
        public static readonly Func<T> CreateInstance = FastConstructorGenerator.Generate<T>();
    }

    public static class FastConstructorGenerator
    {
        private static class Params
        {
            public const string Name = "GeneratedFastConstructor";
            public static readonly Type[] ParameterTypes = new Type[0];
            public static readonly Module Module = typeof(FastConstructorGenerator).Module;
            public const bool SkipVisibility = true;
        }

        public static Func<T> Generate<T>() where T : new()
        {
            Expression<Func<T>> constructorRawDefinition = () => new T();
            var constructorDefinition = (NewExpression)constructorRawDefinition.Body;
            var constructorType = constructorDefinition.Type;

            var methodInfo = new DynamicMethod(Params.Name, constructorType, Params.ParameterTypes,
                Params.Module, Params.SkipVisibility);

            var ilGenerator = methodInfo.GetILGenerator();

            var constructorInfo = constructorDefinition.Constructor;
            if (constructorInfo != null)
            {
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

            return (Func<T>)methodInfo.CreateDelegate(typeof(Func<T>));
        }
    }
}
