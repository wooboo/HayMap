using AutoMapper;
using HayMap.Mapper;

namespace HayMap.Automapper
{
    public static class AutoMapperExtensions
    {
        public static ConvertUsing<object, TDest> UsingDynamicMapper<TDest>(this object source)
        {
            var engine = AutoMapper.Mapper.Engine;
            return new ConvertUsing<object, TDest>(source, new DynamicMapper<object, TDest>(engine));
        }

        public static ConvertUsing<object, TDest> UsingAutoMapper<TDest>(this object source)
        {
            var engine = AutoMapper.Mapper.Engine;
            return new ConvertUsing<object, TDest>(source, new AutoMapper<object, TDest>(engine));
        }
    }

    public static class MappingEnigneMapperExtensions
    {
        public static ConvertUsing<object, TDest> UsingDynamicMappingEngine<TDest>(this object source,
            IMappingEngine engine)
        {
            return new ConvertUsing<object, TDest>(source, new DynamicMapper<object, TDest>(engine));
        }

        public static ConvertUsing<object, TDest> UsingAutoMappingEngine<TDest>(this object source,
            IMappingEngine engine)
        {
            return new ConvertUsing<object, TDest>(source, new AutoMapper<object, TDest>(engine));
        }
    }
}