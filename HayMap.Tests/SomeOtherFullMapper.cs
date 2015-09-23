using HayMap.Mapper;

namespace HayMap.Tests
{
    public class SomeOtherFullMapper : IFullMapper<SomeType, SomeOtherType>
    {
        public SomeOtherType Create(SomeType source)
        {
            return new SomeOtherType(source.Value);
        }

        public void Update(SomeType source, SomeOtherType dest)
        {
            dest.UpdateOtherValue(source.Value);
        }
    }
}