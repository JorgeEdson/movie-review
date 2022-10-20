using MovieReview.Core.Domain.Base;
using System.Collections.Generic;

namespace MovieReview.Core.Domain.Entities
{
    public class Director : Person
    {
        public virtual List<Title> Titles { get; set; }
    }
}
