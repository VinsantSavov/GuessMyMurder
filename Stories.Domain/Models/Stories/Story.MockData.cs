using Stories.Domain.Models.Characters;

namespace Stories.Domain.Models.Stories
{
    public class StoryMockData
    {
        private const string TITLE = "title";
        private const string PLOT = "That brings us to the topic of story – how do we help guide the narrative of our games so that they are";

        public static IEnumerable<object[]> ValidParams
        => new List<object[]>
        {
            new object[]
            { 
                Guid.NewGuid(),
                TITLE,
                PLOT,
            },
        };

        public static IEnumerable<object[]> InvalidParams
        => new List<object[]>
        {
            new object[]
            {
                Guid.Empty,
                string.Empty,
                string.Empty,
            },
        };

        public static IEnumerable<object[]> InvalidCreatorId
        => new List<object[]>
        {
            new object[]
            {
                Guid.Empty,
                TITLE,
                PLOT,
            },
        };

        public static IEnumerable<object[]> InvalidTitle
        {
            get
            {
                yield return new object[] { Guid.NewGuid(), string.Empty, PLOT };
                yield return new object[] { Guid.NewGuid(), " ", PLOT };
                yield return new object[] { Guid.NewGuid(), null, PLOT };
                yield return new object[] { Guid.NewGuid(), "ti", PLOT };
                yield return new object[] { Guid.NewGuid(), "That brings us to the topic of story – how do we help guide", PLOT };
            }
        }

        public static IEnumerable<object[]> InvalidPlot
        {
            get
            {
                yield return new object[] { Guid.NewGuid(), TITLE, string.Empty };
                yield return new object[] { Guid.NewGuid(), TITLE, " " };
                yield return new object[] { Guid.NewGuid(), TITLE, null };
                yield return new object[] { Guid.NewGuid(), TITLE, "plot" };
            }
        }

        public static IEnumerable<object[]> UpdateWithInvalidTitle
        {
            get
            {
                yield return new object[] { Guid.NewGuid(), TITLE, PLOT, string.Empty };
                yield return new object[] { Guid.NewGuid(), TITLE, PLOT, " " };
                yield return new object[] { Guid.NewGuid(), TITLE, PLOT, null };
                yield return new object[] { Guid.NewGuid(), TITLE, PLOT, "ti" };
                yield return new object[] { Guid.NewGuid(), TITLE, PLOT, "That brings us to the topic of story – how do we help guide" };
            }
        }

        public static IEnumerable<object[]> UpdateWithInvalidPlot
        {
            get
            {
                yield return new object[] { Guid.NewGuid(), TITLE, PLOT, string.Empty };
                yield return new object[] { Guid.NewGuid(), TITLE, PLOT, " " };
                yield return new object[] { Guid.NewGuid(), TITLE, PLOT, null };
                yield return new object[] { Guid.NewGuid(), TITLE, PLOT, "plot" };
            }
        }

        public static IEnumerable<object[]> ValidParamsWithCharacter
        => new List<object[]>
        {
            new object[]
            {
                Guid.NewGuid(),
                TITLE,
                PLOT,
                GetCharacter(),
            },
        };

        public static IEnumerable<object[]> ValidParamsWithCharacters
        => new List<object[]>
        {
            new object[]
            {
                Guid.NewGuid(),
                TITLE,
                PLOT,
                GetCharacter(),
                GetCharacter("first", "second", "spot"),
            },
        };

        public static IEnumerable<object[]> InvalidCharactersCount
        => new List<object[]>
        {
            new object[]
            {
                Guid.NewGuid(),
                TITLE,
                PLOT,
                GetCharacters(31),
            },
        };

        private static Character GetCharacter(
            string firstName = "firstName",
            string lastName = "lastName",
            string spotlight = "spotlight")
        => new Character(firstName, lastName, spotlight);

        private static IEnumerable<Character> GetCharacters(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                yield return GetCharacter("firstName" + i, "lastName" + i, "spotlight" + i);
            }
        }
    }
}
