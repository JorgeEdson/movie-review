using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReview.Core.Dto.Response
{
    public class UserResponseDto
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string AddedBy { get; set; }
    }
}
