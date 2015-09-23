namespace HayMap.Mapper
{
    public class ConvertUsing<TSource, TDest> : IConverUsingFullMapper<TDest> 
    {
        private readonly IFullMapper<TSource, TDest> _mapper;
        private readonly TSource _source;

        public ConvertUsing(TSource source, IFullMapper<TSource, TDest> mapper)
        {
            _source = source;
            _mapper = mapper;
        }

        public TDest Create()
        {
            return _mapper.Create(_source);
        }

        public TDest Update(TDest dest)
        {
            _mapper.Update(_source, dest);
            return dest;
        }
    }
}