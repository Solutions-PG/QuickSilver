namespace SolutionsPG.QuickSilver.Core.System
{
    public interface IServiceLocationResolver
    {
        T Resolve<T>();
    }
}