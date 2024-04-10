namespace Stories.Application.Stories.Commands.EditCharacter
{
    public class EditCharacterResponseModel
    {
        internal EditCharacterResponseModel(int id)
        {
            this.Id = id;
        }

        public int Id { get; }
    }
}
