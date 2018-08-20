using System.Collections.Generic;

namespace SolutionsPG.QuickSilver2.Demo.Core.Validation
{
    public struct Invalid
    {
        internal readonly IEnumerable<Error> Errors;
        public Invalid(IEnumerable<Error> errors) { Errors = errors; }
    }
}