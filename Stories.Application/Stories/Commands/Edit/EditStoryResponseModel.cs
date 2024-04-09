namespace Stories.Application.Stories.Commands.Edit
{
    public class EditStoryResponseModel
    {
        internal EditStoryResponseModel(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; }
    }
}
