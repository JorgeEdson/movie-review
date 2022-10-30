using MovieReview.Core.Domain.Base;
using System;
using System.Collections.Generic;

namespace MovieReview.Core.Domain.Entities
{
    public class Screenwriter : Person
    {
        public virtual List<Title> Titles { get; private set; }

        public Screenwriter(string name, DateTime birthDate)
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
