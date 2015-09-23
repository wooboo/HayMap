namespace HayMap.Mapper
{
    public interface IUpdatableMapper<in TSource, TDest>
    {
        void Update(TSource source, TDest dest);
    }
}