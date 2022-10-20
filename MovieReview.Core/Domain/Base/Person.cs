using System;

namespace MovieReview.Core.Domain.Base
{
    public abstract class Person : Entity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
