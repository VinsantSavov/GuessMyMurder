﻿namespace Common.Domain.Events.Stories
{
    public class StoryTitleUpdatedEvent : IDomainEvent
    {
        public StoryTitleUpdatedEvent(
            Guid id,
            string title)
        {
            this.Id = id;
            this.Title = title;
        }

        public Guid Id { get; }

        public string Title { get; }
    }
}
