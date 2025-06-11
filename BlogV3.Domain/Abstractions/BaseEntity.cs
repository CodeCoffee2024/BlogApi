namespace BlogV3.Domain.Abstractions
{
    public abstract record class BaseEntity
    {
        #region Properties

        public Guid? Id { get; set; }

        #endregion Properties
    }
}