﻿namespace Stories.Application.Stories.Commands.Create
{
    public class CreateStoryResponseModel
    {
        internal CreateStoryResponseModel(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
