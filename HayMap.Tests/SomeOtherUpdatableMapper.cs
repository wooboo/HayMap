using HayMap.Mapper;

namespace HayMap.Tests
{
    public class SomeOtherUpdatableMapper : IUpdatableMapper<SomeType, SomeOtherType>
    {
        public void Update(SomeType source, SomeOtherType dest)
        {
            dest.UpdateOtherValue(source.Value);
        }
    }
}