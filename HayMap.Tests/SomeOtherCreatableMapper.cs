using HayMap.Mapper;

namespace HayMap.Tests
{
    public class SomeOtherCreatableMapper : ICreatableMapper<SomeType, SomeOtherType>
    {
        public SomeOtherType Create(SomeType source)
        {
            return new SomeOtherType(source.Value);
        }
    }
}