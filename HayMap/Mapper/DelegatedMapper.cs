using System;

namespace HayMap.Mapper
{
    public class DelegatedMapper<TSource, TDest> : IFullMapper<TSource, TDest>
    {
        private readonly Func<TSource, TDest> _create;
        private readonly Action<TSource, TDest> _update;

        public DelegatedMapper(Func<TSource, TDest> create, Action<TSource, TDest> update)
        {
            _create = create;
            _update = update;
        }

        public TDest Create(TSource source)
        {
            return _create(source);
        }

        public void Update(TSource source, TDest dest)
        {
            _update(source, dest);
        }
    }

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