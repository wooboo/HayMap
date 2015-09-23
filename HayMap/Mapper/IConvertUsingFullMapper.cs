namespace HayMap.Mapper
{
    public interface IConvertUsingFullMapper<TDest> : IConvertUsingCreatableMapper<TDest>,
        IConvertUsingUpdatableMapper<TDest>
    {
        
    }
}