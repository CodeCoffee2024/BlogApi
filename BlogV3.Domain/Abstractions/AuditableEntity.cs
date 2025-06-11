using BlogV3.Domain.Entities;

namespace BlogV3.Domain.Abstractions
{
    public abstract record class AuditableEntity : BaseEntity
    {
        #region Properties

        public DateTime? CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public virtual User? CreatedBy { get; init; }
        public virtual User? UpdatedBy { get; init; }
        public Guid? CreatedById { get; private set; }
        public Guid? UpdatedById { get; private set; }

        #endregion Properties

        protected void SetUpdated(Guid updatedById, DateTime updatedOn)
        {
            UpdatedById = updatedById;
            UpdatedOn = updatedOn;
        }
        protected void SetCreated(Guid createdById, DateTime createdOn)
        {
            CreatedById = createdById;
            CreatedOn = createdOn;
            UpdatedById = createdById;
            UpdatedOn = createdOn;
        }
    }
}