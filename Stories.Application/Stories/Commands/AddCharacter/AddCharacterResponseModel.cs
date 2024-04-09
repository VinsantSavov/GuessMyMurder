namespace Stories.Application.Stories.Commands.AddCharacter
{
    public class AddCharacterResponseModel
    {
        public AddCharacterResponseModel(int id)
        {
            this.Id = id;
        }

        public int Id { get; }
    }
}
