namespace HayMap.Mapper
{
    public interface ICreatingAndUpdatingMapper<in TSource, TDest> : ICreatingMapper<TSource, TDest>, IUpdatableMapper<TSource, TDest>
    {
    }
}