using System;
using SolutionsPG.QuickSilver2.Demo.Core.Validation;

namespace SolutionsPG.QuickSilver2.Demo.Core
{
    public static class OptionValidationExtensions
    {
        public static Validation<T> ToValidation<T>(this Option<T> opt, Func<Error> error)
            => opt.Match(
                () => F.Invalid(error()),
                F.Valid);
    }
}