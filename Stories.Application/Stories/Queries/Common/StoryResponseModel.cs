using AutoMapper;

using Common.Application.Mapping;

using Stories.Domain.Models.Stories;

namespace Stories.Application.Stories.Queries.Common
{
    public class StoryResponseModel : IMapFrom<Story>, IHaveCustomMappings
    {
        public Guid CreatorId { get; private set; }

        public string Title { get; private set; }

        public string Plot { get; private set; }

        public string PlotSummary => this.Plot.Substring(0, 128) + "...";

        public string CreatedOn { get; private set; }

        public void CreateMappings(IProfileExpression config)
        {
            config.CreateMap<Story, StoryResponseModel>()
                .ForMember(sm => sm.CreatedOn, s => s.MapFrom(y => y.CreatedOn.ToString("HH:mm MM/dd/yyyy")));
        }
    }
}
