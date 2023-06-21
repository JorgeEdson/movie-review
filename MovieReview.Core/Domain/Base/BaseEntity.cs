using MovieReview.Core.Domain.Entities;
using System;

namespace MovieReview.Core.Domain.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid? UserId { get; private set; }
        public User User { get; set; }

        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }

        public void SetWhoAdded(Guid paramWhoAddedId)
        {
            UserId = paramWhoAddedId;
        }
    }
}
