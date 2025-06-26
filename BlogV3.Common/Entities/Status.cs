using System.ComponentModel;

namespace BlogV3.Common.Entities
{
    public enum Status
    {
        [Description("activ")]
        Active,

        [Description("inact")]
        Inactive,

        [Description("forve")]
        ForVerification,

        [Description("")]
        None,
    }
}