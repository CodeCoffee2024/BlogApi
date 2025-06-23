namespace BlogV3.Application.Dtos
{
    public class PermissionDto
    {
        #region Properties

        public string Name { get; private set; }
        public virtual ModuleDto Module { get; private set; }

        #endregion Properties
    }
}