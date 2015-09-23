namespace HayMap.Mapper
{
    public interface IConverUsingFullMapper<TDest> : IConvertUsingCreatableMapper<TDest>,
        IConvertUsingUpdatableMapper<TDest>
    {
        
    }
}