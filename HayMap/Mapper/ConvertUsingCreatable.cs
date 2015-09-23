namespace HayMap.Mapper
{
    public class ConvertUsingCreatable<TSource, TDest> : IConvertUsingCreatableMapper<TDest>
    {
        private readonly ICreatableMapper<TSource, TDest> _mapper;
        private readonly TSource _source;

        public ConvertUsingCreatable(TSource source, ICreatableMapper<TSource, TDest> mapper)
        {
            _source = source;
            _mapper = mapper;
        }

        public TDest Create()
        {
            return _mapper.Create(_source);
        }
    }
}