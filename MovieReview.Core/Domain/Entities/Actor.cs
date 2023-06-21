using MovieReview.Core.Domain.Base;
using System;
using System.Collections.Generic;

namespace MovieReview.Core.Domain.Entities
{
    public class Actor : Person
    {
        public List<Title>? Titles { get; protected set; }
        
        public Actor(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
            Titles = new();
        }

        public Actor()
        {}

        public void SetTitles(List<Title> titles) => Titles = titles;
        
    }
}
