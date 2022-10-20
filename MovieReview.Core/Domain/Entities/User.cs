using MovieReview.Core.Domain.Base;
using MovieReview.Core.Domain.Entities.Enuns;
using System.Collections.Generic;

namespace MovieReview.Core.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }

        public virtual List<Review> Reviews { get; set; }
    }
}
