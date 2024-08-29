namespace EventMatcha.Domain.Primitives
{
    public abstract class Entity : IAuditable
    {
        protected Entity(Guid id) => Id = id;

        protected Entity() { }

        public Guid Id { get; protected set; }

        public DateTime CreatedOn { get; protected set; }
        public string? CreatedBy { get; protected set; } = string.Empty;
        public DateTime? ModifiedOn { get; protected set; }
        public string? ModifiedBy { get; protected set; } = string.Empty;
        public bool IsDeleted { get; set; }
    }
}
