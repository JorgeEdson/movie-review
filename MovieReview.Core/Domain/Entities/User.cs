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

        public User() => SetDefaultValues();
        

        private void SetDefaultValues()
        {
            Password = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3";
            SetToCommonUser();
            Reviews = new List<Review>();
        }

        public void SetToCommonUser() => IsAdministrator = false;
        public void SetToAdministrator() => IsAdministrator = true;
        public void SetPassword(string paramPassword) => Password = paramPassword;
        public void SetEmail(string paramEmail) => Email = paramEmail;
        
    }
}
