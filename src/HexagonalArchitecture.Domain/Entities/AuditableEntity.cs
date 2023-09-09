namespace HexagonalArchitecture.Domain.Entities
{
    public abstract class AuditableEntity
    {
        protected AuditableEntity() { }
        public DateTime CreatedAt { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public long? UpdatedBy { get; set; }

    }
}
