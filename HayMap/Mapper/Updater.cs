namespace HayMap.Mapper
{
    public class Updater<TSource, TDest> : IUpdate<TDest>
    {
        private readonly IUpdatableMapper<TSource, TDest> _mapper;
        private readonly TSource _source;

        public Updater(TSource source, IUpdatableMapper<TSource, TDest> mapper)
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