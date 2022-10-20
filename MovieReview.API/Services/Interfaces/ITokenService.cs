using MovieReview.Core.Domain.Entities;


namespace MovieReview.API.Services.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
