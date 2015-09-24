using AutoMapper;
using HayMap.Mapper;

namespace HayMap.Automapper
{
    public class AutoMapper<TSource, TDest> : ICreatingAndUpdatingMapper<TSource, TDest>
    {
        private readonly IMappingEngine _mappingEngine;

        public AutoMapper(IMappingEngine mappingEngine)
        {
            _mappingEngine = mappingEngine;
        }

        public TDest Create(TSource source)
        {
            return (TDest) _mappingEngine.Map(source, source.GetType(), typeof (TDest));
        }

        public void Update(TSource source, TDest dest)
        {
            _mappingEngine.Map(source, dest, source.GetType(), dest.GetType());
        }
    }
}