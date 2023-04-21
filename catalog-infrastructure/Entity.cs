namespace catalog_infrastructure
{
    public abstract class Entity
    {
        public Entity(Guid id)
        {
            Id = id;
        }
        public Entity()
        { }

        public Guid Id { get; set; }
    }
}