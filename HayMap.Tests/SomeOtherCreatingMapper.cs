using HayMap.Mapper;

namespace HayMap.Tests
{
    public class SomeOtherCreatingMapper : ICreatingMapper<SomeType, SomeOtherType>
    {
        public SomeOtherType Create(SomeType source)
        {
            return new SomeOtherType(source.Value);
        }
    }
}