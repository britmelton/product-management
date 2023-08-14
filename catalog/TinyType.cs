namespace Catalog
{
    public abstract class TinyType<T> : ValueObject where T : notnull
    {
        protected TinyType(T value)
        {
            Value = value;
        }

        public T Value { get; }

        public static implicit operator T(TinyType<T> source) => source.Value;

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}