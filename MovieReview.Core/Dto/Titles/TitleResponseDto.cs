using MovieReview.Core.Domain.Entities.Enums;
using MovieReview.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Core.Dto.Titles
{
    public class TitleResponseDto
    {
        public string TitleMovie { get;  set; }
        public TypeMovie TypeMovie { get; set; }
        public Genre Genre { get;  set; }
        public int Duration { get;  set; }
        public string Synopsis { get;  set; }        
        public string DirectorName { get; set; }
        
    }
}
