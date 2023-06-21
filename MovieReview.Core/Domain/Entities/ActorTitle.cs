using MovieReview.Core.Domain.Base;
using System;

namespace MovieReview.Core.Domain.Entities
{
    public class ActorTitle : BaseEntity
    {
        public Guid TitleId { get; set; }
        public virtual Title Title { get; set; }
        public Guid ActorId { get; set; }
        public virtual Actor Actor { get; set; }

        public ActorTitle()
        { }
    }
}
