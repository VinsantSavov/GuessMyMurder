using Xunit;

using Stories.Domain.Exceptions;

namespace Stories.Domain.Models.Characters
{
    public class CharacterSpecs
    {
        private const string PREFIX = "valid";

        [Theory]
        [MemberData(nameof(CharacterMockData.ValidParams), MemberType = typeof(CharacterMockData))]
        public void CreateCharacter_WithValidParameters(string firstName, string lastName, string spotLight)
        {
            var character = new Character(firstName, lastName, spotLight);

            Assert.NotNull(character);
            Assert.Equal(firstName, character.FirstName);
            Assert.Equal(lastName, character.LastName);
            Assert.Equal(spotLight, character.Spotlight);
        }

        [Theory]
        [MemberData(nameof(CharacterMockData.InvalidParams), MemberType = typeof(CharacterMockData))]
        public void CreateCharacter_WithInvalidParameters_ShouldThrowException(string firstName, string lastName, string spotLight)
        {
            Assert.Throws<InvalidStoryException>(() => new Character(firstName, lastName, spotLight));
        }

        [Theory]
        [MemberData(nameof(CharacterMockData.InvalidFirstName), MemberType = typeof(CharacterMockData))]
        public void CreateCharacter_WithInvalidFirstName_ShouldThrowException(string firstName, string lastName, string spotLight)
        {
            Assert.Throws<InvalidStoryException>(() => new Character(firstName, lastName, spotLight));
        }

        [Theory]
        [MemberData(nameof(CharacterMockData.InvalidLastName), MemberType = typeof(CharacterMockData))]
        public void CreateCharacter_WithInvalidLastName_ShouldThrowException(string firstName, string lastName, string spotLight)
        {
            Assert.Throws<InvalidStoryException>(() => new Character(firstName, lastName, spotLight));
        }

        [Theory]
        [MemberData(nameof(CharacterMockData.EmptySpotlight), MemberType = typeof(CharacterMockData))]
        public void CreateCharacter_WithEmptySpotlight_ShouldReturnCharacter(string firstName, string lastName, string? spotLight)
        {
            var character = new Character(firstName, lastName, spotLight);

            Assert.NotNull(character);
            Assert.Equal(firstName, character.FirstName);
            Assert.Equal(lastName, character.LastName);
            Assert.Equal(spotLight, character.Spotlight);
        }

        [Theory]
        [MemberData(nameof(CharacterMockData.ValidParamsWithoutSpotlight), MemberType = typeof(CharacterMockData))]
        public void CreateCharacter_WithoutSpotlight_ShouldReturnCharacter(string firstName, string lastName)
        {
            var character = new Character(firstName, lastName);

            Assert.NotNull(character);
            Assert.Equal(firstName, character.FirstName);
            Assert.Equal(lastName, character.LastName);
            Assert.Null(character.Spotlight);
        }

        [Theory]
        [MemberData(nameof(CharacterMockData.ValidParams), MemberType = typeof(CharacterMockData))]
        public void UpdateFirstName_WithValidName_ShouldReturnCharacter(string firstName, string lastName, string spotLight)
        {
            var updateFirstName = PREFIX + firstName;
            var character = new Character(firstName, lastName, spotLight).UpdateFirstName(updateFirstName);

            Assert.NotNull(character);
            Assert.Equal(updateFirstName, character.FirstName);
            Assert.Equal(lastName, character.LastName);
            Assert.Equal(spotLight, character.Spotlight);
        }

        [Theory]
        [MemberData(nameof(CharacterMockData.UpdateWithInvalidName), MemberType = typeof(CharacterMockData))]
        public void UpdateFirstName_WithInvalidName_ShouldThrowException(string firstName, string lastName, string spotLight, string invalidFirstName)
        {
            Assert.Throws<InvalidStoryException>(() => new Character(firstName, lastName, spotLight).UpdateFirstName(invalidFirstName));
        }

        [Theory]
        [MemberData(nameof(CharacterMockData.ValidParams), MemberType = typeof(CharacterMockData))]
        public void UpdateLastName_WithValidName_ShouldReturnCharacter(string firstName, string lastName, string spotLight)
        {
            var updateLastName = PREFIX + lastName;
            var character = new Character(firstName, lastName, spotLight).UpdateLastName(updateLastName);

            Assert.NotNull(character);
            Assert.Equal(firstName, character.FirstName);
            Assert.Equal(updateLastName, character.LastName);
            Assert.Equal(spotLight, character.Spotlight);
        }

        [Theory]
        [MemberData(nameof(CharacterMockData.UpdateWithInvalidName), MemberType = typeof(CharacterMockData))]
        public void UpdateLastName_WithInvalidName_ShouldThrowException(string firstName, string lastName, string spotLight, string invalidLastName)
        {
            Assert.Throws<InvalidStoryException>(() => new Character(firstName, lastName, spotLight).UpdateLastName(invalidLastName));
        }

        [Theory]
        [MemberData(nameof(CharacterMockData.ValidParams), MemberType = typeof(CharacterMockData))]
        public void UpdateSpotlight_WithValidSpotlight_ShouldReturnCharacter(string firstName, string lastName, string spotLight)
        {
            var updateSpotlight = PREFIX + spotLight;
            var character = new Character(firstName, lastName, spotLight).UpdateSpotlight(updateSpotlight);

            Assert.NotNull(character);
            Assert.Equal(firstName, character.FirstName);
            Assert.Equal(lastName, character.LastName);
            Assert.Equal(updateSpotlight, character.Spotlight);
        }

        [Theory]
        [MemberData(nameof(CharacterMockData.UpdateWithEmptySpotlight), MemberType = typeof(CharacterMockData))]
        public void UpdateSpotlight_WithEmptySpotlight_ShouldReturnCharacter(string firstName, string lastName, string spotLight, string emptySpotlight)
        {
            var character = new Character(firstName, lastName, spotLight).UpdateSpotlight(emptySpotlight);

            Assert.NotNull(character);
            Assert.Equal(firstName, character.FirstName);
            Assert.Equal(lastName, character.LastName);
            Assert.Equal(string.Empty, character.Spotlight);
        }
    }
}
