namespace HayMap.Mapper
{
    public class Creator<TSource, TDest> : ICreate<TDest>
    {
        private readonly ICreatingMapper<TSource, TDest> _mapper;
        private readonly TSource _source;

        public Creator(TSource source, ICreatingMapper<TSource, TDest> mapper)
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