using HayMap.Mapper;

namespace HayMap.Tests
{
    public class SomeOtherSimpleUpdatableMapper : IUpdatableMapper<SomeType, SomeOtherSimpleType>
    {
        public void Update(SomeType source, SomeOtherSimpleType dest)
        {
            dest.OtherValue = source.Value;
        }
    }
}