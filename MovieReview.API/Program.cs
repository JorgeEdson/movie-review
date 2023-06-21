using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MovieReview.API;
using MovieReview.API.Services;
using MovieReview.Database.Repositories.Interfaces;
using MovieReview.Database.Repositories;
using MovieReview.Database.Services.Interfaces;
using MovieReview.Database.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var key = Encoding.ASCII.GetBytes(JWT.JwtKey);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(UserMapper));



builder.Services.AddTransient<TokenService>();

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IUserService, UserService>();

builder.Services.AddSingleton<IActorRepository, ActorRepository>();
builder.Services.AddSingleton<IActorService, ActorService>();

builder.Services.AddSingleton<IDirectorRepository, DirectorRepository>();
builder.Services.AddSingleton<IDirectorService, DirectorService>();

builder.Services.AddSingleton<ITitleRepository, TitleRepository>();
builder.Services.AddSingleton<ITitleService, TitleService>();

builder.Services.AddSingleton<IActorTitleRepository, ActorTitleRepository>();
builder.Services.AddSingleton<IActorTitleService, ActorTitleService>();

builder.Services.AddSingleton<IReviewRepository, ReviewRepository>();
builder.Services.AddSingleton<IReviewService, ReviewService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();