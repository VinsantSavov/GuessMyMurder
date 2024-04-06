using Common.Domain.Models;
using Common.Domain.Constants;
using Common.Domain.Models.Entities;

using Stories.Domain.Exceptions;

namespace Stories.Domain.Models.Characters
{
    public class Character : BaseModel<int>
    {
        internal Character(
            string firstName,
            string lastName,
            string? spotlight = null)
        {
            this.ValidateName(firstName);
            this.ValidateName(lastName);
            this.ValidateSpotlight(spotlight);

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Spotlight = spotlight;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string? Spotlight { get; private set; }

        public Character UpdateFirstName(string firstName)
        {
            this.ValidateName(firstName);

            this.FirstName = firstName;

            return this;
        }

        public Character UpdateLastName(string lastName)
        {
            this.ValidateName(lastName);

            this.LastName = lastName;

            return this;
        }

        public Character UpdateSpotlight(string? spotlight)
        {
            this.ValidateSpotlight(spotlight);

            this.Spotlight = spotlight;

            return this;
        }

        #region Validation

        private void ValidateName(string name)
            => Guard.ForStringLength<InvalidStoryException>(
                name,
                StringConstants.MinNameLength,
                StringConstants.MaxNameLength);

        private void ValidateSpotlight(string? spotlight)
            => Guard.ForMaxStringLength<InvalidStoryException>(
                spotlight,
                StringConstants.MaxStoryLength);

        #endregion
    }
}
