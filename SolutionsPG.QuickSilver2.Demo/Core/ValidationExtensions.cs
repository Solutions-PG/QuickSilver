using System;
using System.Linq;

namespace SolutionsPG.QuickSilver2.Demo.Core
{
    public static class ValidationExtensions
    {
        public static Validation<R> Apply<T, R>(this Validation<Func<T, R>> valF, Validation<T> valT)
           => valF.Match(
              valid: (f) => valT.Match((err) => F.Invalid(err), (t) => F.Valid(f(t))),
              invalid: (errF) => valT.Match((errT) => F.Invalid(errF.Concat(errT)), (_) => F.Invalid(errF)));
        
        public static Validation<R> Map<T, R>(this Validation<T> valT, Func<T, R> f) => valT.Match(F.Invalid<R>, (t) => F.Valid(f(t)));
        public static Validation<R> Bind<T, R>(this Validation<T> valT, Func<T, Validation<R>> f) => valT.Match(F.Invalid<R>, f);
    }
}