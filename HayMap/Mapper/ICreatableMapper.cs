namespace HayMap.Mapper
{
    public interface ICreatableMapper<in TSource, out TDest>
    {
        TDest Create(TSource source);
    }
}