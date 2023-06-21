using MovieReview.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MovieReview.Core.Domain.Base
{
    public abstract class Person : BaseEntity
    {
        public string Name { get;  protected set; }
        public DateTime BirthDate { get; protected set; }
    }
}
