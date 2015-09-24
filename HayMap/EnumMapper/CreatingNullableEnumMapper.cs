using System;
using System.Reflection;
using HayMap.Mapper;

namespace HayMap.EnumMapper
{
    public class CreatingNullableEnumMapper<TSource, TDest> : ICreatingMapper<TSource, TDest>
    {
        private readonly TDest _default;
        private bool _throwIfNotFound = false;
        private ICreatingMapper<TSource, TDest> _mapper;
        public CreatingNullableEnumMapper()
        {
            _throwIfNotFound = true;
            _mapper = new CreatingEnumMapper<TSource, TDest>();
        }
        public CreatingNullableEnumMapper(TDest @default)
        {
            _default = @default;
            _mapper = new CreatingEnumMapper<TSource, TDest>(@default);
        }

        public TDest Create(TSource source)
        {
            //var t = source.GetType();
            //if ((bool) t.GetTypeInfo().GetDeclaredProperty("HasValue").GetValue(source))
            if(source!=null)
            {
                //return _mapper.Create(t.GetTypeInfo().GetDeclaredProperty("Value").GetValue(source));
                return _mapper.Create(source);
            }
            if (_throwIfNotFound)
            {
                throw new ArgumentOutOfRangeException("Element not found in enum");
            }

            return _default;
        }
    }
}