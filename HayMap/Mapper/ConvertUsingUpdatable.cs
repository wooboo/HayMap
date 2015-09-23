namespace HayMap.Mapper
{
    public class ConvertUsingUpdatable<TSource, TDest> : IConvertUsingUpdatableMapper<TDest>
    {
        private readonly IUpdatableMapper<TSource, TDest> _mapper;
        private readonly TSource _source;

        public ConvertUsingUpdatable(TSource source, IUpdatableMapper<TSource, TDest> mapper)
        {
            _source = source;
            _mapper = mapper;
        }

        public TDest Update(TDest dest)
        {
            _mapper.Update(_source, dest);
            return dest;
        }
    }
}