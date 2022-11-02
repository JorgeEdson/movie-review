using MovieReview.Core.Domain.Base;
using MovieReview.Core.Domain.Entities.Enums;
using MovieReview.Core.Domain.Entities.Enuns;
using System;
using System.Collections.Generic;

namespace MovieReview.Core.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Password { get; private set; }
        public Roles Role { get; private set; }
        public  virtual List<Review> Reviews { get; private set; }

        public User(string name, string pasword, Roles role) : base()
        {
            Name = name;
            Password = pasword;
            Role = role;
            Reviews = new List<Review>();
        }

        public void WriteReviewAboutTitle(Title title ,string description, int note) 
        {
            Review review = new();
            
            review.SetUser(this);
            review.SetTitle(title);
            review.SetDescription(description);
            review.SetNote(note);

            AddReview(review);
        }

        private void AddReview(Review review) 
        {
            Reviews.Add(review);
        }

        public bool ChangePasssword(string oldPassword, string newPassword) 
        {
            if (Password == oldPassword) 
            { 
                Password = newPassword;
                return true;
            }
            else
                return false;
        }

        public Title SetUpTitle(string titleMovie,TypeMovie typeMovie, Genre genre, int duration, string synopsis,
            Director director, Screenwriter screenwriter, List<Actor> actors) 
        {
            if (Role == Roles.Administrator)
            {
                var title = new Title();

                title.SetTitleMovie(titleMovie);
                title.SetTypeMovie(typeMovie);
                title.SetGenre(genre);
                title.SetDuration(duration);
                title.SetSynopsis(synopsis);
                title.SetDirector(director);
                title.SetScreenwriter(screenwriter);
                title.SetActors(actors);
                return title;
            }
            else
                throw new Exception("This User dont have permission.");
        }
    }
}
