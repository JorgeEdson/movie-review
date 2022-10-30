using MovieReview.Core.Domain.Base;
using System;
using System.Collections.Generic;

namespace MovieReview.Core.Domain.Entities
{
    public class Director : Person
    {
        public virtual List<Title> Titles { get; private set; }

        public Director(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public void SetTitles(List<Title> titles)
        {
            Titles = titles;
        }
    }
}
