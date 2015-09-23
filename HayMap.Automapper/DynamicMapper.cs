using AutoMapper;
using HayMap.Mapper;

namespace HayMap.Automapper
{
    public class DynamicMapper<TSource, TDest> : IFullMapper<TSource, TDest>
    {
        private readonly IMappingEngine _mappingEngine;

        public DynamicMapper(IMappingEngine mappingEngine)
        {
            _mappingEngine = mappingEngine;
        }

        public TDest Create(TSource source)
        {
            return (TDest) _mappingEngine.DynamicMap(source, source.GetType(), typeof (TDest));
        }

        public void Update(TSource source, TDest dest)
        {
            _mappingEngine.DynamicMap(source, dest, source.GetType(), dest.GetType());
        }
    }
}