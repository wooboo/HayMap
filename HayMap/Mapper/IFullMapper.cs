namespace HayMap.Mapper
{
    public interface IFullMapper<in TSource, TDest> : ICreatableMapper<TSource, TDest>, IUpdatableMapper<TSource, TDest>
    {
    }
}