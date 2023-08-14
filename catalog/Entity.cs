namespace catalog
{
    public abstract class Entity
    {
        public Entity(Guid? id = default)
        {
            Id = id is null || id == Guid.Empty ? Guid.NewGuid() : id.Value;
        }

        public Guid Id { get; }
    }
}