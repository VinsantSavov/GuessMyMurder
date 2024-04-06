using Common.Domain.Exceptions;

namespace Games.Domain.Exceptions
{
    public class InvalidGameException : BaseDomainException
    {
        public InvalidGameException()
        {
        }

        public InvalidGameException(string error)
        {
            this.Error = error;
        }
    }
}
