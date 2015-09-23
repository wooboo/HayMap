namespace HayMap.Mapper
{
    public interface IConvertUsingUpdatableMapper<TDest>
    {
        TDest Update(TDest dest);
    }
}