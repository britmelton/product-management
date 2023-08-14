using FluentAssertions;

namespace Catalog.Spec.TinyTypes
{
    public class ValueObjectSpec
    {
        public abstract class WhenEvaluatingEquality
        {
            public abstract ValueObject Create();
            public abstract ValueObject CreateOther();

            [Fact]
            public void WithSameReference_ThenReturnTrue()
            {
                var valueObject1 = Create();
                var valueObject2 = valueObject1;

                valueObject2.Should().BeSameAs(valueObject1);

                (valueObject1 == valueObject2).Should().BeTrue();
                (valueObject1 != valueObject2).Should().BeFalse();
            }

            [Fact]
            public void WithSameValues_ThenReturnTrue()
            {
                var valueObject1 = Create();
                var valueObject2 = Create();

                valueObject2.Should().Be(valueObject1);
                valueObject2.Should().NotBeSameAs(valueObject1);

                (valueObject1 == valueObject2).Should().BeTrue();
                (valueObject1 != valueObject2).Should().BeFalse();
            }

            [Fact]
            public void WithDifferentStructure_ThenReturnFalse()
            {
                var valueObject1 = Create();
                var valueObject2 = CreateOther();

                valueObject2.Should().NotBe(valueObject1);

                (valueObject1 == valueObject2).Should().BeFalse();
                (valueObject1 != valueObject2).Should().BeTrue();
            }

            [Fact]
            public void WithNullReference_ThenReturnFalse()
            {
                var valueObject1 = Create();
                ValueObject? nullObject = null;

                valueObject1.Should().NotBe(nullObject);
                nullObject.Should().NotBe(valueObject1);

                (valueObject1 == null).Should().BeFalse();
                (valueObject1 != null).Should().BeTrue();

                (null == valueObject1).Should().BeFalse();
                (null != valueObject1).Should().BeTrue();
            }

            [Fact]
            public void WithTwoNullReferences_ThenReturnTrue()
            {
                ValueObject? nullObject1 = null;
                ValueObject? nullObject2 = null;

                nullObject1.Should().Be(nullObject2);

                (nullObject1 == nullObject2).Should().BeTrue();
                (nullObject2 != nullObject1).Should().BeFalse();
            }

            [Fact]
            public void WithOtherType_ThenReturnFalse()
            {
                var valueObject1 = Create();
                var valueObject2 = new Foo();

                valueObject1.Should().NotBe(valueObject2);

                (valueObject1 == valueObject2).Should().BeFalse();
                (valueObject1 != valueObject2).Should().BeTrue();
            }
        }

        public class Foo : ValueObject
        {
            public override IEnumerable<object> GetEqualityComponents()
            {
                yield return (byte)255;
                yield return (byte)0;
                yield return (byte)0;
            }
        }
    }
}