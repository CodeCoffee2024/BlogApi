namespace BlogV3.Application.Dtos
{
    public class PermissionDto
    {
        #region Properties

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public virtual ModuleDto Module { get; private set; }

        #endregion Properties
    }
}