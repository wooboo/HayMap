namespace HayMap.Mapper
{
    public interface IConvertUsingCreatableMapper<out TDest>
    {
        TDest Create();
    }
}