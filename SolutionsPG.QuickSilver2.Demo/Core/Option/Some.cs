using System;

namespace SolutionsPG.QuickSilver2.Demo.Core.Option
{
    public struct Some<T>
    {
        internal T Value { get; }

        internal Some(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value)
                    , "Cannot wrap a null value in a 'Some'; use 'None' instead");
            this.Value = value;
        }
    }
}