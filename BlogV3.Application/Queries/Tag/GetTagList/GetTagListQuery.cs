using MediatR;

namespace BlogV3.Application.Queries.Tag.GetTagList
{
    public class GetTagListQuery : IRequest<GetTagListResponse>
    {
        #region Properties

        public GetTagListQuery(string name)
        {
            Name = name;
        }

        public string Name { get; set; } = string.Empty;

        #endregion Properties
    }
}