using MovieReview.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MovieReview.Core.Domain.Base
{
    public abstract class Person : Entity
    {
        public string Name { get;  protected set; }
        public DateTime BirthDate { get; protected set; }
        public virtual List<Title> Titles { get; protected set; }

        public void SetTitles(List<Title> titles)
        {
            Titles = titles;
        }

    }
}
