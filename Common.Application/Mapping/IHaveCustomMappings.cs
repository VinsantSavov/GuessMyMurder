using AutoMapper;

namespace Common.Application.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression config);
    }
}
