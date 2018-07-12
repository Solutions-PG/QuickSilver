namespace SolutionsPG.QuickSilver.Core.Functional.Option
{
    public struct Some<T>
    {
        internal T Value { get; }
        internal Some(T value) => this.Value = value;
    }
}
