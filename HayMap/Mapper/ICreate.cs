namespace HayMap.Mapper
{
    public interface ICreate<out TDest>
    {
        TDest Create();
    }
}