using System;
using System.Globalization;
using HayMap.Mapper;

namespace HayMap.EnumMapper
{

    public class CreatingEnumMapper<TSource, TDest> : ICreatingMapper<TSource, TDest>
    {
        private readonly TDest _default;
        private bool _throwIfNotFound = false;
        public CreatingEnumMapper()
        {
            _throwIfNotFound = true;
        }
        public CreatingEnumMapper(TDest @default)
        {
            _default = @default;
        }

        public TDest Create(TSource source)
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
