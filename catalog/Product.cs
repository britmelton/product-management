namespace Catalog
{
    public partial class Product : Entity
    {
        public Product(string description, string name, Sku sku, ProductStatus status = ProductStatus.Staged, Guid id = default) : base(id)
        {
            Description = description;
            Name = name;
            Sku = sku;
            Status = status;
        }

        public string Description { get; set; }
        public string Name { get; set; }
        public Sku Sku { get; set; }
        private State _state;
        private ProductStatus _status;
        public ProductStatus Status
        {
            get => _status;
            private set
            {
                _status = value;
                _state = _states[_status](this);
            }
        }

        private readonly Dictionary<ProductStatus, Func<Product, State>> _states = new()
        {
            { ProductStatus.Activated, x => new Activated(x) },
            { ProductStatus.Deactivated, x => new Deactivated(x) },
            { ProductStatus.Staged, x => new Staged(x) }
        };

        public void Activate() => _state.Activate();

        public void Deactivate() => _state.Deactivate();

        public void Stage() => _state.Stage();

        public string EditName(string newName)
        {
            Name = newName;
            return Name;
        }

        public string EditDescription(string newDescription)
        {
            Description = newDescription;
            return Description;
        }
    }
}