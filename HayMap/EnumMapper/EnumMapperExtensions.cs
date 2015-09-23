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

        public static IConvertUsingCreatableMapper<TDest> UsingEnumMapper<TDest>(this object source)
        {
            
            ICreatableMapper<object, TDest> creatableEnumMapper;

            Type type = source.GetType();
            if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) &&
                Nullable.GetUnderlyingType(type).GetTypeInfo().IsEnum)
            {
                creatableEnumMapper = new CreatableNullableEnumMapper<TDest>();
            }
            else if (type.GetTypeInfo().IsEnum)
            {
                creatableEnumMapper = new CreatableEnumMapper<TDest>();
            }
            else
            {
                throw new NotSupportedException("Enum or Nullable Enum is only supported");
            }

            return new ConvertUsingCreatable<object, TDest>(source, creatableEnumMapper);
        }

        public static IConvertUsingCreatableMapper<TDest> UsingEnumMapperWithDefault<TSource, TDest>(this TSource source, TDest @default)
        {
            ICreatableMapper<object, TDest> creatableEnumMapper;

            Type type = typeof(TSource);
            if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof (Nullable<>) &&
                Nullable.GetUnderlyingType(type).GetTypeInfo().IsEnum)
            {
                creatableEnumMapper = new CreatableNullableEnumMapper<TDest>(@default);
            }
            else if (type.GetTypeInfo().IsEnum)
            {
                creatableEnumMapper = new CreatableEnumMapper<TDest>(@default);
            }
            else
            {
                throw new NotSupportedException("Enum or Nullable Enum is only supported");
            }

            return new ConvertUsingCreatable<object, TDest>(source, creatableEnumMapper);
        }
    }
}