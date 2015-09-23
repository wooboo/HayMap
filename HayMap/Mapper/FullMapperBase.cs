namespace HayMap.Mapper
{
    public abstract class FullMapperBase<TSource, TDest> : IFullMapper<TSource, TDest> 
        where TDest : class, new()
    {
        public TDest Create(TSource source)
        {
            if (source == null)
            {
                return null;
            }
            var dest = new TDest();
            Update(source, dest);
            return dest;
        }

        public abstract void Update(TSource source, TDest dest);
    }
}