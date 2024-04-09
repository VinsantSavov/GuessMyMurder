using Xunit;

using Stories.Domain.Exceptions;
using Stories.Domain.Models.Characters;

namespace Stories.Domain.Models.Stories
{
    public class StorySpecs
    {
        private const string PREFIX = "valid";

        [Theory]
        [MemberData(nameof(StoryMockData.ValidParams), MemberType = typeof(StoryMockData))]
        public void CreateStory_WithValidParameters(Guid creatorId, string title, string plot)
        {
            var story = new Story(creatorId, title, plot);

            Assert.NotNull(story);
            Assert.Equal(creatorId, story.CreatorId);
            Assert.Equal(title, story.Title);
            Assert.Equal(plot, story.Plot);
            Assert.Empty(story.Characters);
        }

        [Theory]
        [MemberData(nameof(StoryMockData.InvalidParams), MemberType = typeof(StoryMockData))]
        public void CreateStory_WithInvalidParameters_ShouldThrowException(Guid creatorId, string title, string plot)
        {
            Assert.Throws<InvalidStoryException>(() => new Story(creatorId, title, plot));
        }

        [Theory]
        [MemberData(nameof(StoryMockData.InvalidCreatorId), MemberType = typeof(StoryMockData))]
        public void CreateStory_WithInvalidCreatorId_ShouldThrowException(Guid creatorId, string title, string plot)
        {
            Assert.Throws<InvalidStoryException>(() => new Story(creatorId, title, plot));
        }

        [Theory]
        [MemberData(nameof(StoryMockData.InvalidTitle), MemberType = typeof(StoryMockData))]
        public void CreateStory_WithInvalidTitle_ShouldThrowException(Guid creatorId, string title, string plot)
        {
            Assert.Throws<InvalidStoryException>(() => new Story(creatorId, title, plot));
        }

        [Theory]
        [MemberData(nameof(StoryMockData.InvalidPlot), MemberType = typeof(StoryMockData))]
        public void CreateStory_WithInvalidPlot_ShouldThrowException(Guid creatorId, string title, string plot)
        {
            Assert.Throws<InvalidStoryException>(() => new Story(creatorId, title, plot));
        }

        [Theory]
        [MemberData(nameof(StoryMockData.ValidParams), MemberType = typeof(StoryMockData))]
        public void UpdateTitle_WithValidTitle_ShouldReturnStory(Guid creatorId, string title, string plot)
        {
            var updateTitle = PREFIX + title;
            var story = new Story(creatorId, title, plot).UpdateTitle(updateTitle);

            Assert.NotNull(story);
            Assert.Equal(creatorId, story.CreatorId);
            Assert.Equal(updateTitle, story.Title);
            Assert.Equal(plot, story.Plot);
            Assert.Empty(story.Characters);
        }

        [Theory]
        [MemberData(nameof(StoryMockData.UpdateWithInvalidTitle), MemberType = typeof(StoryMockData))]
        public void UpdateTitle_WithInvalidTitle_ShouldThrowException(Guid creatorId, string title, string plot, string invalidTitle)
        {
            Assert.Throws<InvalidStoryException>(() => new Story(creatorId, title, plot).UpdateTitle(invalidTitle));
        }

        [Theory]
        [MemberData(nameof(StoryMockData.ValidParams), MemberType = typeof(StoryMockData))]
        public void UpdatePlot_WithValidPlot_ShouldReturnStory(Guid creatorId, string title, string plot)
        {
            var updatePlot = PREFIX + plot;
            var story = new Story(creatorId, title, plot).UpdatePlot(updatePlot);

            Assert.NotNull(story);
            Assert.Equal(creatorId, story.CreatorId);
            Assert.Equal(title, story.Title);
            Assert.Equal(updatePlot, story.Plot);
            Assert.Empty(story.Characters);
        }

        [Theory]
        [MemberData(nameof(StoryMockData.UpdateWithInvalidPlot), MemberType = typeof(StoryMockData))]
        public void UpdatePlot_WithInvalidPlot_ShouldThrowException(Guid creatorId, string title, string plot, string invalidPlot)
        {
            Assert.Throws<InvalidStoryException>(() => new Story(creatorId, title, plot).UpdatePlot(invalidPlot));
        }

        [Theory]
        [MemberData(nameof(StoryMockData.ValidParamsWithCharacter), MemberType = typeof(StoryMockData))]
        public void AddCharacter_ShouldAddAndReturnStory(
            Guid creatorId,
            string title,
            string plot,
            Character character)
        {
            var story = new Story(creatorId, title, plot).AddCharacter(character);

            Assert.NotNull(story);
            Assert.NotEmpty(story.Characters);
            Assert.Single(story.Characters);
            Assert.Equal(character.FirstName, story.Characters.First().FirstName);
            Assert.Equal(character.LastName, story.Characters.First().LastName);
            Assert.Equal(character.Spotlight, story.Characters.First().Spotlight);
        }

        [Theory]
        [MemberData(nameof(StoryMockData.InvalidCharactersCount), MemberType = typeof(StoryMockData))]
        public void AddCharacter_WithInvalidCharactersCount_ShouldThrowException(
            Guid creatorId,
            string title,
            string plot,
            IEnumerable<Character> characters)
        {
            Assert.Throws<InvalidStoryException>(() =>
            {
                var story = new Story(creatorId, title, plot);

                foreach (var character in characters)
                {
                    story.AddCharacter(character);
                }
            });
        }

        [Theory]
        [MemberData(nameof(StoryMockData.ValidParamsWithCharacter), MemberType = typeof(StoryMockData))]
        public void AddCharacterByProperties_ShouldAddAndReturnStory(
            Guid creatorId,
            string title,
            string plot,
            Character character)
        {
            var story = new Story(creatorId, title, plot).AddCharacter(
                                                           character.FirstName, 
                                                           character.LastName, 
                                                           character.Spotlight);

            Assert.NotNull(story);
            Assert.NotEmpty(story.Characters);
            Assert.Single(story.Characters);
            Assert.Equal(character.FirstName, story.Characters.First().FirstName);
            Assert.Equal(character.LastName, story.Characters.First().LastName);
            Assert.Equal(character.Spotlight, story.Characters.First().Spotlight);
        }

        [Theory]
        [MemberData(nameof(StoryMockData.ValidParamsWithCharacter), MemberType = typeof(StoryMockData))]
        public void RemoveCharacter_ShouldRemoveAndReturnStory(
            Guid creatorId,
            string title,
            string plot,
            Character character)
        {
            var story = new Story(creatorId, title, plot).AddCharacter(character)
                                                         .RemoveCharacter(character);

            Assert.NotNull(story);
            Assert.Empty(story.Characters);
        }

        [Theory]
        [MemberData(nameof(StoryMockData.ValidParamsWithCharacters), MemberType = typeof(StoryMockData))]
        public void RemoveCharacter_WithNonExistingCharacter_ShouldReturnStory(
            Guid creatorId,
            string title,
            string plot,
            Character characterToAdd,
            Character characterToRemove)
        {
            var story = new Story(creatorId, title, plot).AddCharacter(characterToAdd)
                                                         .RemoveCharacter(characterToRemove);

            Assert.NotNull(story);
            Assert.NotEmpty(story.Characters);
            Assert.Single(story.Characters);
            Assert.Equal(characterToAdd.FirstName, story.Characters.First().FirstName);
            Assert.Equal(characterToAdd.LastName, story.Characters.First().LastName);
            Assert.Equal(characterToAdd.Spotlight, story.Characters.First().Spotlight);
        }
    }
}
