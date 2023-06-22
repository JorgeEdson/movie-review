using MovieReview.Core.Domain.Base;
using MovieReview.Core.Domain.Entities;
using System;

namespace MovieReview.Core.Domain.Entities
{
    public class Review : BaseEntity
    {
        public int Note { get; private set; }
        public string Description { get; private set; }        
        public Guid TitleId { get; private set; }
        public virtual Title Title { get; private set; }

        public Review()
        {}

        public void SetDescription(string description) => Description = description;    
        public void SetNote(int note) => Note = note;
        public void SetUser(User user) => User = user;
        public void SetTitle(Title title) => Title = title;
        
    }
}
