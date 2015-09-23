namespace HayMap.Mapper
{
    public class FullFromUpdatableMapper<TSource, TDest> : IFullMapper<TSource, TDest>
        where TDest: class, new()
    {
        private readonly IUpdatableMapper<TSource, TDest> _innerMapper;

        public FullFromUpdatableMapper(IUpdatableMapper<TSource, TDest> innerMapper)
        {
            _innerMapper = innerMapper;
        }

        public TDest Create(TSource source)
        {
            var dest = new TDest();
            _innerMapper.Update(source, dest);
            return dest;
        }

        public void Update(TSource source, TDest dest)
        {
            _innerMapper.Update(source, dest);
        }
    }
}