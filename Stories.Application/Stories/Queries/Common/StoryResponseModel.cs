using Common.Application.Mapping;

using Stories.Domain.Models.Stories;

namespace Stories.Application.Stories.Queries.Common
{
    public class StoryResponseModel
    {
        public Guid CreatorId { get; private set; }

        public string Title { get; private set; }

        public string PlotSummary { get; private set; }
    }
}
