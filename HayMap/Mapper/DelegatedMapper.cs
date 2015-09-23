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
}