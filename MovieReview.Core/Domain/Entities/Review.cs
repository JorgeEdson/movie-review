using MovieReview.Core.Domain.Base;

namespace MovieReview.Core.Domain.Entities
{
    public class Review : Entity
    {
        public int Note { get; protected set; }
        public string Description { get; protected set; }
        public int IdUser { get; set; }
        public virtual User User { get; set; }
        public int IdTitle { get; set; }
        public virtual Title Title { get; set; }
    }
}
