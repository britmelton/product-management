namespace catalog
{
    public abstract class TinyType<T> : ValueObject where T : notnull
    {
        public T Value { get; }

        protected TinyType(T value)
        {
            Value = value;
        }

        public static implicit operator T(TinyType<T> source) => source.Value;

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
