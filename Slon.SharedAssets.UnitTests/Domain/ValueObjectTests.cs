using Slon.SharedAssets.Domain;

namespace Slon.SharedAssets.UnitTests.Domain;

public class ValueObjectTests
{
    private sealed class TestValueObject : ValueObject
    {
        public string Value1 { get; }
        public int Value2 { get; }

        public TestValueObject(string value1, int value2)
        {
            Value1 = value1;
            Value2 = value2;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value1;
            yield return Value2;
        }
    }

    [Fact]
    public void Equals_SameObject_ReturnsTrue()
    {
        var obj = new TestValueObject("abc", 123);

        Assert.True(obj.Equals(obj));
    }

    [Fact]
    public void Equals_NullObject_ReturnsFalse()
    {
        var obj = new TestValueObject("abc", 123);

#pragma warning disable CA1508 // Avoid dead conditional code
        Assert.False(obj.Equals(null));
#pragma warning restore CA1508 // Avoid dead conditional code
    }

    [Fact]
    public void Equals_DifferentType_ReturnsFalse()
    {
        var obj = new TestValueObject("abc", 123);
        var differentType = new object();

        Assert.False(obj.Equals(differentType));
    }

    [Fact]
    public void Equals_SameValues_ReturnsTrue()
    {
        var obj1 = new TestValueObject("abc", 123);
        var obj2 = new TestValueObject("abc", 123);

        Assert.True(obj1.Equals(obj2));
    }

    [Fact]
    public void Equals_DifferentValues_ReturnsFalse()
    {
        var obj1 = new TestValueObject("abc", 123);
        var obj2 = new TestValueObject("xyz", 123);

        Assert.False(obj1.Equals(obj2));
    }

    [Fact]
    public void GetHashCode_SameValues_ReturnsSameHashCode()
    {
        var obj1 = new TestValueObject("abc", 123);
        var obj2 = new TestValueObject("abc", 123);

        Assert.Equal(obj1.GetHashCode(), obj2.GetHashCode());
    }

    [Fact]
    public void GetHashCode_DifferentValues_ReturnsDifferentHashCode()
    {
        var obj1 = new TestValueObject("abc", 123);
        var obj2 = new TestValueObject("xyz", 123);

        Assert.NotEqual(obj1.GetHashCode(), obj2.GetHashCode());
    }
}
