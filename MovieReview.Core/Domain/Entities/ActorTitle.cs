using MovieReview.Core.Domain.Base;

namespace MovieReview.Core.Domain.Entities
{
    public class ActorTitle : Entity
    {
        public int IdTitle { get; set; }
        public virtual Title Title { get; set; }
        public int IdActor { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
