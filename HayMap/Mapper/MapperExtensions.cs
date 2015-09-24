using System;

namespace HayMap.Mapper
{
    public static class MapperExtensions
    {
        public static ICreateAndUpdate<TDest> Using<TSource, TDest>(this TSource source,
            ICreatingAndUpdatingMapper<TSource, TDest> mapper)
        {
            return new CreatorAndUpdater<TSource, TDest>(source, mapper);
        }
        public static ICreate<TDest> Using<TSource, TDest>(this TSource source,
            ICreatingMapper<TSource, TDest> mapper)
        {
            return new Creator<TSource, TDest>(source, mapper);
        }
        public static IUpdate<TDest> Using<TSource, TDest>(this TSource source,
            IUpdatableMapper<TSource, TDest> mapper)
        {
            return new Updater<TSource, TDest>(source, mapper);
        }

        public static ICreateAndUpdate<TDest> UsingUpdater<TSource, TDest>(this TSource source,
            IUpdatableMapper<TSource, TDest> mapper) where TDest : class, new()
        {
            return new CreatorAndUpdater<TSource, TDest>(source, new CreatingAndUpdatingFromUpdatableMapper<TSource, TDest>(mapper));
        }

        public static ICreate<TDest> Using<TSource, TDest>(this TSource source,
           Func<TSource, TDest> mapper)
        {
            return new Creator<TSource, TDest>(source, new DelegatedMapper<TSource, TDest>(mapper, null));
        }
        public static IUpdate<TDest> Using<TSource, TDest>(this TSource source,
            Action<TSource, TDest> mapper)
        {
            return new Updater<TSource, TDest>(source, new DelegatedMapper<TSource, TDest>(null, mapper));
        }
        public static ICreateAndUpdate<TDest> UsingUpdater<TSource, TDest>(this TSource source,
            Action<TSource, TDest> mapper)
            where TDest: class, new()
        {
            return new CreatorAndUpdater<TSource, TDest>(source, new CreatingAndUpdatingFromUpdatableMapper<TSource, TDest>(new DelegatedMapper<TSource, TDest>(null, mapper)));
        }
    }
}