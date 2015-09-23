namespace HayMap.Tests
{
    public class SomeOtherType
    {
        public SomeOtherType(int otherValue)
        {
            OtherValue = otherValue;
        }

        public int OtherValue { get; private set; }

        public void UpdateOtherValue(int value)
        {
            OtherValue = value;
        }
    }
}