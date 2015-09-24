using System;
using System.Reflection;
using HayMap.Mapper;

namespace HayMap.EnumMapper
{
    public static class EnumMapperExtensions
    {

        //public static IConvertUsingCreatableMapper<TDest> UsingEnumMapperM<TSource, TDest>(this TSource source)
        //    where TSource: struct, IConvertible
        //{

        //}
        //public static IConvertUsingCreatableMapper<TDest> UsingEnumMapperM<TSource, TDest>(this TSource? source)
        //    where TSource : struct, IConvertible
        //{

        //}

        public static ICreate<TDest> UsingEnumMapper<TSource, TDest>(this TSource source)
        {

            ICreatingMapper<TSource, TDest> creatingEnumMapper;

            Type type = source.GetType();
            if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) &&
                Nullable.GetUnderlyingType(type).GetTypeInfo().IsEnum)
            {
                creatingEnumMapper = new CreatingNullableEnumMapper<TSource, TDest>();
            }
            else if (type.GetTypeInfo().IsEnum)
            {
                creatingEnumMapper = new CreatingEnumMapper<TSource, TDest>();
            }
            else
            {
                throw new NotSupportedException("Enum or Nullable Enum is only supported");
            }

            return new Creator<TSource, TDest>(source, creatingEnumMapper);
        }

        public static ICreate<TDest> UsingEnumMapperWithDefault<TSource, TDest>(this TSource source, TDest @default)
        {
            ICreatingMapper<TSource, TDest> creatingEnumMapper;

            Type type = typeof(TSource);
            if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof (Nullable<>) &&
                Nullable.GetUnderlyingType(type).GetTypeInfo().IsEnum)
            {
                creatingEnumMapper = new CreatingNullableEnumMapper<TSource, TDest>(@default);
            }
            else if (type.GetTypeInfo().IsEnum)
            {
                creatingEnumMapper = new CreatingEnumMapper<TSource, TDest>(@default);
            }
            else
            {
                throw new NotSupportedException("Enum or Nullable Enum is only supported");
            }

            return new Creator<TSource, TDest>(source, creatingEnumMapper);
        }
    }
}