namespace HayMap.Mapper
{
    public interface ICreatingMapper<in TSource, out TDest>
    {
        TDest Create(TSource source);
    }
}