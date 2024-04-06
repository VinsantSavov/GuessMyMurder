namespace Stories.Domain.Models.Characters
{
    public class CharacterMockData
    {
        private const string FIRSTNAME = "firstName";
        private const string LASTNAME = "lastName";
        private const string SPOTLIGHT = "spotlight";
        private const string INVALIDNAME = "veeeeeeeeeeerrrrryyyyyy lonnnnggggggggg nnnaaaaaammmeeeee";

        public static IEnumerable<object[]> ValidParams
        => new List<object[]>
        {
            new object[]
            {
                FIRSTNAME,
                LASTNAME,
                SPOTLIGHT,
            },
        };

        public static IEnumerable<object[]> InvalidParams
        => new List<object[]>
        {
            new object[]
            {
                string.Empty,
                string.Empty,
                string.Empty,
            },
        };

        public static IEnumerable<object[]> InvalidFirstName
        {
            get
            {
                yield return new object[] { string.Empty, LASTNAME, SPOTLIGHT };
                yield return new object[] { " ", LASTNAME, SPOTLIGHT };
                yield return new object[] { null, LASTNAME, SPOTLIGHT };
                yield return new object[] { "fi", LASTNAME, SPOTLIGHT };
                yield return new object[] { INVALIDNAME, LASTNAME, SPOTLIGHT };
            }
        }

        public static IEnumerable<object[]> InvalidLastName
        {
            get
            {
                yield return new object[] { FIRSTNAME, string.Empty, SPOTLIGHT };
                yield return new object[] { FIRSTNAME, " ", SPOTLIGHT };
                yield return new object[] { FIRSTNAME, null, SPOTLIGHT };
                yield return new object[] { FIRSTNAME, "la", SPOTLIGHT };
                yield return new object[] { FIRSTNAME, INVALIDNAME, SPOTLIGHT };
            }
        }

        public static IEnumerable<object[]> EmptySpotlight
        {
            get
            {
                yield return new object[] { FIRSTNAME, LASTNAME, string.Empty };
                yield return new object[] { FIRSTNAME, LASTNAME, null };
            }
        }

        public static IEnumerable<object[]> ValidParamsWithoutSpotlight
        => new List<object[]>
        {
            new object[]
            {
                FIRSTNAME,
                LASTNAME,
            },
        };

        public static IEnumerable<object[]> UpdateWithInvalidName
        {
            get
            {
                yield return new object[] { FIRSTNAME, LASTNAME, SPOTLIGHT, string.Empty };
                yield return new object[] { FIRSTNAME, LASTNAME, SPOTLIGHT, " " };
                yield return new object[] { FIRSTNAME, LASTNAME, SPOTLIGHT, null };
                yield return new object[] { FIRSTNAME, LASTNAME, SPOTLIGHT, "fi" };
                yield return new object[] { FIRSTNAME, LASTNAME, SPOTLIGHT, INVALIDNAME };

            }
        }

        public static IEnumerable<object[]> UpdateWithEmptySpotlight
        => new List<object[]>
        {
            new object[]
            {
                FIRSTNAME,
                LASTNAME,
                SPOTLIGHT,
                string.Empty,
            },
        };
    }
}
