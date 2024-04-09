namespace Common.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entity, string id)
            : base($"Entity ({entity}) with id - {id} was not found!")
        {
        }
    }
}
