using MovieReview.Core.Domain.Entities.Enuns;
using MovieReview.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Core.Dto
{
    public class UserDto
    {
        public string Name { get;  set; }
        public string Password { get;  set; }
        public Roles Role { get;  set; }
        public virtual List<Review> Reviews { get; set; }
    }
}
