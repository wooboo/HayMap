using System;
using System.Globalization;
using HayMap.Mapper;

namespace HayMap.EnumMapper
{

    public class CreatableEnumMapper<TDest> : ICreatableMapper<object, TDest>
    {
        private readonly TDest _default;
        private bool _throwIfNotFound = false;
        public CreatableEnumMapper()
        {
            _throwIfNotFound = true;
        }
        public CreatableEnumMapper(TDest @default)
        {
            _default = @default;
        }

        public TDest Create(object source)
        {
            var intValue = Convert.ToInt32(source, CultureInfo.InvariantCulture);
            if (Enum.IsDefined(typeof(TDest), intValue))
            {
                return (TDest)Enum.ToObject(typeof(TDest), intValue);
            }
            if (_throwIfNotFound)
            {
                throw new ArgumentOutOfRangeException("Element not found in enum");
            }
            return _default;
        }
    }
}
