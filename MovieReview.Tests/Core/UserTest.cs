using MovieReview.Core.Domain.Entities;
using MovieReview.Core.Domain.Entities.Enums;
using MovieReview.Core.Domain.Entities.Enuns;
using Xunit;

namespace MovieReview.Tests.Core
{
    public class UserTest
    {
        [Fact]
        public async Task CreateUser_WithValidData_ReturnUser() 
        {
            //arrange
            string name = "User Test";
            string password = "123456";
            Roles role = Roles.Administrator;
            User user = new(name, password, role);
            //action
            //assert
            Assert.NotNull(user);
            Assert.Equal(name, user.Name);
            Assert.Equal(password, user.Password);
            Assert.Equal(role, user.Role);
            Assert.NotNull(user.Reviews);
        }



        [Fact]
        public async Task WriteReviewAboutTitle_WithValidData_AddOneInListReviews()
        {
            //arrange
            User user = new("Bernardo", "123456", Roles.CommonUser);
            Title title = new();
            string description = "The best movie of my life!!!";
            int note = 10;

            //action
            user.WriteReviewAboutTitle(title, description, note);

            var review = user.Reviews.Where(r => r.Title == title).FirstOrDefault();

            //asserts
            Assert.Single(user.Reviews);
            Assert.Equal(note, review.Note);
            Assert.Equal(title, review.Title);
            Assert.Equal(description, review.Description);
        }

        [Fact]
        public async Task ChangePasssword_WithValidData_ReturnsTrue()
        {
            //arrange
            User user = new("Bernardo", "123456", Roles.CommonUser);

            //action
            var data = user.ChangePasssword("123456", "654321");

            //asserts
            Assert.True(data);
        }

        [Fact]
        public async Task ChangePasssword_WithInvalidData_ReturnsFalse()
        {
            //arrange
            User user = new("Bernardo", "123456", Roles.CommonUser);

            //action
            var data = user.ChangePasssword("654321", "111000");

            //asserts
            Assert.False(data);
        }

        [Fact]
        public async Task SetUpTitle_WithValidData_ReturnTitleIfUserIsAdministrator() 
        {
            //arrange
            User user = new("Bernardo", "123456", Roles.Administrator);
            string titleMovie = "MovieTest";
            TypeMovie typeMovie = TypeMovie.Movie;
            Genre genre = Genre.Musical;
            int duration = 100;
            string synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et " +
                              "dolore magna aliqua. Arcu risus quis varius quam quisque id diam. Quisque sagittis purus sit amet.";
            
            Director director = new("Director Test",new DateTime(1970,11,2));
            
            Screenwriter screenwriter = new("Screenwriter Test", new DateTime(1975, 4, 30));

            Actor actor1 = new("Actor Test 1", new DateTime(1992, 8, 15));
            Actor actor2 = new("Actor Test 2", new DateTime(1993, 9, 16));
            Actor actor3 = new("Actor Test 3", new DateTime(2013, 3, 11));
            Actor actor4 = new("Actor Test 4", new DateTime(2014, 4, 21));

            List<Actor> actors = new();
            actors.Add(actor1);
            actors.Add(actor2);
            actors.Add(actor3);
            actors.Add(actor4);


            //action
            var title = user.SetUpTitle(titleMovie, typeMovie, genre, duration, synopsis, director, screenwriter, actors);

            //asserts
            Assert.NotNull(title);
            Assert.Equal(titleMovie, title.TitleMovie);
            Assert.Equal(typeMovie, title.TypeMovie);
            Assert.Equal(genre, title.Genre);
            Assert.Equal(duration, title.Duration);
            Assert.Equal(synopsis, title.Synopsis);
            Assert.Equal(director, title.Director);
            Assert.Equal(screenwriter, title.Screenwriter);
            Assert.Equal(actors, title.Actors);
        }

        [Fact]
        public async Task SetUpTitle_WithValidData_ReturnExceptionIfUserIsCommonUser()
        {
            //arrange
            User user = new("Bernardo", "123456", Roles.CommonUser);
            string titleMovie = "MovieTest";
            TypeMovie typeMovie = TypeMovie.Movie;
            Genre genre = Genre.Musical;
            int duration = 100;
            string synopsis = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et " +
                              "dolore magna aliqua. Arcu risus quis varius quam quisque id diam. Quisque sagittis purus sit amet.";

            Director director = new("Director Test", new DateTime(1970, 11, 2));

            Screenwriter screenwriter = new("Screenwriter Test", new DateTime(1975, 4, 30));

            Actor actor1 = new("Actor Test 1", new DateTime(1992, 8, 15));
            Actor actor2 = new("Actor Test 2", new DateTime(1993, 9, 16));
            Actor actor3 = new("Actor Test 3", new DateTime(2013, 3, 11));
            Actor actor4 = new("Actor Test 4", new DateTime(2014, 4, 21));

            List<Actor> actors = new();
            actors.Add(actor1);
            actors.Add(actor2);
            actors.Add(actor3);
            actors.Add(actor4);

            //action
            Action action = () => user.SetUpTitle(titleMovie, typeMovie, genre, duration, synopsis, director, screenwriter, actors);            

            //asserts
            Assert.Throws<Exception>(action);
        }
    }
}
