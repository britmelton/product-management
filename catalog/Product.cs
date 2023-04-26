﻿namespace catalog
{
    public partial class Product
    {
        public string Description { get; set; }
        public Guid Id { get; }
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

        public Product(string description, string name, Sku sku, Guid id = default)
        {
            Description = description;
            Name = name;
            Sku = sku;
            Id = id == default ? Guid.NewGuid() : id;
            Status = ProductStatus.Staged;
        }

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
