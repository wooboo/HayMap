using System;

namespace HayMap.Mapper
{
    public static class MapperExtensions
    {
        public static IConvertUsingFullMapper<TDest> Using<TSource, TDest>(this TSource source,
            IFullMapper<TSource, TDest> mapper)
        {
            return new ConvertUsing<TSource, TDest>(source, mapper);
        }
        public static IConvertUsingCreatableMapper<TDest> Using<TSource, TDest>(this TSource source,
            ICreatableMapper<TSource, TDest> mapper)
        {
            return new ConvertUsingCreatable<TSource, TDest>(source, mapper);
        }
        public static IConvertUsingUpdatableMapper<TDest> Using<TSource, TDest>(this TSource source,
            IUpdatableMapper<TSource, TDest> mapper)
        {
            return new ConvertUsingUpdatable<TSource, TDest>(source, mapper);
        }

        public static IConvertUsingFullMapper<TDest> UsingUpdater<TSource, TDest>(this TSource source,
            IUpdatableMapper<TSource, TDest> mapper) where TDest : class, new()
        {
            return new ConvertUsing<TSource, TDest>(source, new FullFromUpdatableMapper<TSource, TDest>(mapper));
        }

        public static IConvertUsingCreatableMapper<TDest> Using<TSource, TDest>(this TSource source,
           Func<TSource, TDest> mapper)
        {
            return new ConvertUsingCreatable<TSource, TDest>(source, new DelegatedMapper<TSource, TDest>(mapper, null));
        }
        public static IConvertUsingUpdatableMapper<TDest> Using<TSource, TDest>(this TSource source,
            Action<TSource, TDest> mapper)
        {
            return new ConvertUsingUpdatable<TSource, TDest>(source, new DelegatedMapper<TSource, TDest>(null, mapper));
        }
        public static IConvertUsingFullMapper<TDest> UsingUpdater<TSource, TDest>(this TSource source,
            Action<TSource, TDest> mapper)
            where TDest: class, new()
        {
            return new ConvertUsing<TSource, TDest>(source, new FullFromUpdatableMapper<TSource, TDest>(new DelegatedMapper<TSource, TDest>(null, mapper)));
        }
    }
}