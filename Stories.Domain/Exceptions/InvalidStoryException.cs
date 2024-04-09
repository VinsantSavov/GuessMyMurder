﻿using Common.Domain.Exceptions;

namespace Stories.Domain.Exceptions
{
    public class InvalidStoryException : BaseDomainException
    {
        public InvalidStoryException()
        {
        }

        public InvalidStoryException(string error)
        {
            this.Error = error;
        }
    }
}
