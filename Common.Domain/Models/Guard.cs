using Common.Domain.Exceptions;

namespace Common.Domain.Models
{
    public static class Guard
    {
        public static void AgainstEmptyString<TException>(string value)
            where TException : BaseDomainException, new()
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            ThrowException<TException>("Value can not be null or whitespace!");
        }

        public static void ForStringLength<TException>(string value, int minLength, int maxLength)
            where TException : BaseDomainException, new()
        {
            AgainstEmptyString<TException>(value);

            if (value.Length >= minLength 
                && value.Length <= maxLength)
            {
                return;
            }

            ThrowException<TException>($"Value string length must be between: {minLength} - {maxLength} chars!");
        }

        public static void ForMaxStringLength<TException>(string? value, int maxLength)
            where TException : BaseDomainException, new()
        {
            if (string.IsNullOrWhiteSpace(value)
                || value.Length <= maxLength)
            {
                return;
            }

            ThrowException<TException>($"Value max string length must be less than {maxLength} chars!");
        }

        public static void ForInvalidGuid<TException>(Guid value)
            where TException : BaseDomainException, new()
        {
            if (value != Guid.Empty)
            {
                return;
            }

            ThrowException<TException>("Guid can not be empty!");
        }

        public static void ForCollectionCount<TException>(int collectionCount, int minCount = 0, int maxCount = int.MaxValue)
            where TException : BaseDomainException, new()
        {
            if (collectionCount >= minCount
                && collectionCount <= maxCount)
            {
                return;
            }

            ThrowException<TException>($"Collection count must be between {minCount} - {maxCount}!");
        }

        private static void ThrowException<TException>(string message)
            where TException : BaseDomainException, new()
        {
            var exception = new TException()
            {
                Error = message,
            };

            throw exception;
        }
    }
}
