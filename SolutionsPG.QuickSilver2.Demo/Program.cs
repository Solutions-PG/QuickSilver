//using System;
//using System.Collections.Generic;
//using SolutionsPG.QuickSilver2.Demo.Core;

//namespace SolutionsPG.QuickSilver2.Demo
//{
//    public class Program
//    {
//        private struct LocalInput
//        {
//            public string value1;
//            public string value2;
//        }

//        private struct ServiceInput
//        {
//        }

//        private struct ServiceOutput
//        {
//        }

//        private struct LocalOutput
//        {
//        }

//        static void Main(string[] args)
//        {
//            LocalInput localInput;
//            Handle(localInput)
//                .Match(HandleErrors,
//                    ex => ex.Match(
//                        HandleException,
//                        HandleSuccess));
//        }

//        private static Validation<Exceptional<LocalOutput>> Handle(Option<LocalInput> localInput)
//        {
//            return Validate(localInput)
//                .Map(ConvertToServiceInput)
//                .Bind(CallService)
//                .Map(ConvertToLocalOutput);
//        }

//        private static Validation<LocalInput> Validate(Option<LocalInput> optLocalInput)
//        {
//            return optLocalInput
//                .ToValidation("No local input provided")
//                .Bind(i => HarvestErrorsFrom(ValidateValue1(i.value1), ValidateValue2(i.value2));
//        }

//        private static object ValidateValue1(Option<string> value1)
//        {
//            return value1
//                .Where(DelegateUtils.Not<string>(string.IsNullOrEmpty))
//                .ToValidation("No local input provided")
//                .Bind(i => HarvestErrorsFrom(ValidateValue1(i.value1), ValidateValue2(i.value2));
//        }

//        private static object ValidateValue2(string argValue2)
//        {
//            throw new NotImplementedException();
//        }

//        private static ServiceInput ConvertToServiceInput(string s)
//        {
//            return default;
//        }

//        private static Validation<Exceptional<ServiceOutput>> CallService(ServiceInput s)
//        {
//            return F.TryExecute(ServiceFunc).Traverse(o => o.Errors.IsNullOrEmpty() ? F.Valid(o) : F.Invalid(o.Errors));
//        }

//        private static LocalOutput ConvertToLocalOutput(ServiceOutput optArgs)
//        {
//            return default;
//        }

//        private static LocalOutput HandleErrors(IEnumerable<Error> errors)
//        {
//            return default;
//        }

//        private static LocalOutput HandleException(Exception exception)
//        {
//            return default;
//        }

//        private static LocalOutput HandleSuccess(LocalOutput localOutput)
//        {
//            return localOutput;
//        }
//    }

//    namespace Core
//    {
//        internal static class DelegateUtils
//        {
//            public static Func<T, bool> Not<T>(Func<T, bool> predicate)
//            {
//                return Closure.Not(predicate);
//            }

//            internal static partial class Closure
//            {
//                public static Func<T, bool> Not<T>(Func<T, bool> predicate) => new NotClosure<T>(predicate).Not;

//                private struct NotClosure<T>
//                {
//                    private readonly Func<T, bool> _predicate;

//                    public NotClosure(Func<T, bool> predicate)
//                    {
//                        _predicate = predicate;
//                    }

//                    public bool Not(T t) => _predicate(t) == false;

//                }
//            }
//        }
//    }
//}
