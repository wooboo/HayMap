namespace HayMap.Mapper
{
    public interface IUpdate<TDest>
    {
        TDest Update(TDest dest);
    }
}