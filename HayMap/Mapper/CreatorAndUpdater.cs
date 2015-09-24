namespace HayMap.Mapper
{
    public class CreatorAndUpdater<TSource, TDest> : ICreateAndUpdate<TDest> 
    {
        private readonly ICreatingAndUpdatingMapper<TSource, TDest> _mapper;
        private readonly TSource _source;

        public CreatorAndUpdater(TSource source, ICreatingAndUpdatingMapper<TSource, TDest> mapper)
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