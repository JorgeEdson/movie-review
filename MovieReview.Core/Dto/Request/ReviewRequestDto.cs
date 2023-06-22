using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Core.Dto
{
    public  class ReviewRequestDto
    {
        public int Note { get; set; }
        public string Description { get; set; }
        public Guid TitleId { get; set; }
    }
}
