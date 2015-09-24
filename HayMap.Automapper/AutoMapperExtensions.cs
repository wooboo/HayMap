using AutoMapper;
using HayMap.Mapper;

namespace HayMap.Automapper
{
    public static class AutoMapperExtensions
    {
        public static CreatorAndUpdater<object, TDest> UsingDynamicMapper<TDest>(this object source)
        {
            var engine = AutoMapper.Mapper.Engine;
            return new CreatorAndUpdater<object, TDest>(source, new DynamicMapper<object, TDest>(engine));
        }

        public static CreatorAndUpdater<object, TDest> UsingAutoMapper<TDest>(this object source)
        {
            var engine = AutoMapper.Mapper.Engine;
            return new CreatorAndUpdater<object, TDest>(source, new AutoMapper<object, TDest>(engine));
        }
    }

    public static class MappingEnigneMapperExtensions
    {
        public static CreatorAndUpdater<object, TDest> UsingDynamicMappingEngine<TDest>(this object source,
            IMappingEngine engine)
        {
            return new CreatorAndUpdater<object, TDest>(source, new DynamicMapper<object, TDest>(engine));
        }

        public static CreatorAndUpdater<object, TDest> UsingAutoMappingEngine<TDest>(this object source,
            IMappingEngine engine)
        {
            return new CreatorAndUpdater<object, TDest>(source, new AutoMapper<object, TDest>(engine));
        }
    }
}