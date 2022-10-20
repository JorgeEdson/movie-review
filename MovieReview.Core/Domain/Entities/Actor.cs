using MovieReview.Core.Domain.Base;
using System.Collections.Generic;

namespace MovieReview.Core.Domain.Entities
{
    public class Actor : Person
    {
        public List<Title> Titles { get; set; }
    }
}
