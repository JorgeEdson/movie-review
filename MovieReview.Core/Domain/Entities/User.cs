using MovieReview.Core.Domain.Base;
using MovieReview.Core.Domain.Entities.Enums;
using System;
using System.Collections.Generic;

namespace MovieReview.Core.Domain.Entities
{
    public class User : Person
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsAdministrator { get; private set; }
        public List<Review>? Reviews { get; private set; }

        public User(string paramName, DateTime paramBirthDate)
        {
            SetDefaultValues();
            Name = paramName;
            BirthDate = paramBirthDate;
        }

        public User()
        {}

        private void SetDefaultValues()
        {
            Password = "123";
            SetToCommonUser();
            Reviews = new List<Review>();
        }

        public void SetToCommonUser() => IsAdministrator = false;
        public void SetToAdministrator() => IsAdministrator = true;
        public void SetPassword(string paramPassword) => Password = paramPassword;
        public void SetEmail(string paramEmail) => Email = paramEmail;
        
    }
}
