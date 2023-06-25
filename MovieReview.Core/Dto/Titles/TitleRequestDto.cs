using MovieReview.Core.Domain.Entities.Enums;
using System;

namespace MovieReview.Core.Dto.Titles
{
    public class TitleRequestDto
    {
        public string TitleMovie { get; set; }
        public TypeMovie TypeMovie { get; set; }
        public Genre Genre { get; set; }
        public int Duration { get; set; }
        public string Synopsis { get; set; }
        public Guid DirectorId { get; set; }
        public string Base64Image { get; set; }
    }
}
