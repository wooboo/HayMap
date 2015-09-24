namespace HayMap.Mapper
{
    public class CreatingAndUpdatingFromUpdatableMapper<TSource, TDest> : ICreatingAndUpdatingMapper<TSource, TDest>
        where TDest: class, new()
    {
        private readonly IUpdatableMapper<TSource, TDest> _innerMapper;

        public CreatingAndUpdatingFromUpdatableMapper(IUpdatableMapper<TSource, TDest> innerMapper)
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