namespace BlogV3.Application.Dtos
{
    public class DashboardChartDto
    {
        #region Properties

        public string Title { get; set; }
        public List<string> Labels { get; set; } = new List<string>();
        public List<object> Values { get; set; } = new List<object>();

        #endregion Properties
    }
}
