namespace catalog
{
    public abstract class ValueObject
    {
        public override bool Equals(object? other)
        {
            if (other is null || GetType() != other.GetType())
                return false;

            return GetEqualityComponents()
            .SequenceEqual(((ValueObject)other)
                .GetEqualityComponents());
        }

        public abstract IEnumerable<object> GetEqualityComponents();

        public static bool operator ==(ValueObject? left, ValueObject? right)
        {
            if (left is null && right is null)
                return true;
            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(ValueObject? left, ValueObject? right)
        {
            return !(left == right);
        }
    }
}
