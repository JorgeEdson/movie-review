using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Core.Dto.Actors
{
    public class ActorsInTitleRequestDto
    {
        public Guid IdTitle { get; set; }
        public Guid[] IdsActors { get; set; }
    }

}
