namespace BlogV3.Common.Constants
{
    public static class ModuleGroups
    {
        #region Fields

        public const string DASHBOARD = "Dashboard";
        public const string SYSTEM = "System";

        public static readonly Dictionary<string, string[]> GROUPS = new()
        {
            { DASHBOARD, new[] { Modules.DASHBOARD } },
            { SYSTEM, new[] { Modules.USER, Modules.ROLE, Modules.CATEGORY } }
        };

        #endregion Fields
    }
}