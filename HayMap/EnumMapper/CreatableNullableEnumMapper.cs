using System;
using System.Reflection;
using HayMap.Mapper;

namespace HayMap.EnumMapper
{
    public class CreatableNullableEnumMapper<TDest> : ICreatableMapper<object, TDest>
    {
        private readonly TDest _default;
        private bool _throwIfNotFound = false;
        private ICreatableMapper<object, TDest> _mapper;
        public CreatableNullableEnumMapper()
        {
            _throwIfNotFound = true;
            _mapper = new CreatableEnumMapper<TDest>();
        }
        public CreatableNullableEnumMapper(TDest @default)
        {
            _default = @default;
            _mapper = new CreatableEnumMapper<TDest>(@default);
        }

        public TDest Create(object source)
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