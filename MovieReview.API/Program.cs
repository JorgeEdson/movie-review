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
using MovieReview.API.Mappers;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
ConfigureAuthentication(builder);
ConfigureMvc(builder);
ConfigureServices(builder);
ConfigureMappers(builder);

var app = builder.Build();
LoadConfiguration(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseStaticFiles();
app.Run();

void LoadConfiguration(WebApplication app) 
{
    Configuration.JwtKey = app.Configuration.GetValue<string>("JwtKey");
    Configuration.ApiKeyName = app.Configuration.GetValue<string>("ApiKeyName");
    Configuration.ApiKey = app.Configuration.GetValue<string>("ApiKey");

    var smtp = new Configuration.SmtpConfiguration();
    app.Configuration.GetSection("SmtpConfiguration").Bind(smtp);
    Configuration.Smtp = smtp;
}

void ConfigureAuthentication(WebApplicationBuilder builder)
{
    var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
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
}

void ConfigureMvc(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

void ConfigureMappers(WebApplicationBuilder builder)
{
    builder.Services.AddAutoMapper(typeof(UserMapper));
}

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<TokenService>();
    builder.Services.AddTransient<EmailService>();

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
}