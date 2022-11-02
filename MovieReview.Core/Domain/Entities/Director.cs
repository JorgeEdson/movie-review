using MovieReview.Core.Domain.Base;
using System;
using System.Collections.Generic;

namespace MovieReview.Core.Domain.Entities
{
    public class Director : Person
    {
        public Director(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
            Titles = new List<Title>();
        }        
    }
}
