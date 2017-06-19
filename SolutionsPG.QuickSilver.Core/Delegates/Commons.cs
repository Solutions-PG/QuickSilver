namespace SolutionsPG.QuickSilver.Core.Delegates
{
    public delegate bool FuncTryGet<in T, TResult>(T obj, out TResult result);
}
