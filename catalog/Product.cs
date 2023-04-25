namespace catalog
{
    public class Product
    {
        public string Description { get; set; }
        public Guid Id { get; }
        public bool IsActive { get; set; }
        public bool IsStaged { get; set; }
        public string Name { get; set; }
        public Sku Sku { get; set; }

        public Product(string description, string name, Sku sku, bool isActive = false, bool isStaged = true, Guid id = default)
        {
            Description = description;
            Name = name;
            Sku = sku;
            Id = id == default ? Guid.NewGuid() : id;
            IsActive = isActive;
            IsStaged = isStaged;
        }

        public void Activate()
        {
            IsActive = true;
            IsStaged = false;
        }

        public void Deactivate()
        {
            IsActive = false;
            IsStaged = false;
        }

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
