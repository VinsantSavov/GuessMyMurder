namespace Stories.Application.Stories.Commands.Create
{
    public class CreateStoryResponseModel
    {
        public CreateStoryResponseModel(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
