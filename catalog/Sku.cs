using System.Text.RegularExpressions;

namespace Catalog
{
    public class Sku : TinyType<string>
    {
        public Sku(string value) : base(value)
        {
            if (!Regex.IsMatch(value, "^[a-zA-Z]{3}[0-9]{3}$"))
                throw new ArgumentException("Sku must be 3 letters followed by 3 numbers", nameof(value));
        }

        public static implicit operator Sku(string source) => new(source);
    }
}