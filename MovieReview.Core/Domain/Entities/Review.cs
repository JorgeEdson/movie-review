using MovieReview.Core.Domain.Base;

namespace MovieReview.Core.Domain.Entities
{
    public class Review : Entity
    {
        public int Note { get; private set; }
        public string Description { get; private set; }
        public int IdUser { get; private set; }
        public virtual User User { get; private set; }
        public int IdTitle { get; private set; }
        public virtual Title Title { get; private set; }

        public void SetDescription(string description) 
        {             
            Description = description;
        }

        public void SetNote(int note)
        {
            Note = note;
        }

        public void SetUser(User user) 
        {
            User = user;
        }

        public void SetTitle(Title title) 
        {
            Title = title;
        }
    }
}
