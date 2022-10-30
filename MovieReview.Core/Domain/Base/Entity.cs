using System;

namespace MovieReview.Core.Domain.Base
{
    public abstract class Entity
    {
        public int Id { get; private set; }
        public DateTime CreationDate { get; private set; }

        public Entity()
        {
            CreationDate = DateTime.Now;
        }        
    }
}
