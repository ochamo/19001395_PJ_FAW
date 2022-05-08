using _19001395_PJ_FAW.Endpoint;
using Business.Repository;
using Business.UseCase;
using Business.UseCase.Comic;
using DataAccess;
using DataAccess.DBAccess;
using DataAccess.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme()
            {
                 Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins
        , policy =>
        {
            policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
    };
});
builder.Services.AddAuthorization();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IComicRepository, ComicRepositoryImpl>();
builder.Services.AddSingleton<IEditorialRepository, EditorialRepositoryImpl>();
builder.Services.AddSingleton<ISexRepository, SexRepositoryImpl>();
builder.Services.AddSingleton<IUserRepository, UserRepositoryImpl>();
builder.Services.AddSingleton<CreateUserUseCase>();
builder.Services.AddSingleton<LoginUseCase>();
builder.Services.AddSingleton<GetSexesUseCase>();
builder.Services.AddSingleton<GetEditorialsUseCase>();
builder.Services.AddSingleton<GetComicsUseCase>();
builder.Services.AddSingleton<CreateComicUseCase>();
builder.Services.AddSingleton<DeleteComicUseCase>();
builder.Services.AddSingleton<UpdateComicUseCase>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapGet("/", () => Results.Redirect("/swagger/index.html"));
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(myAllowSpecificOrigins);
app.ConfigureSexApi();
app.ConfigureEditorialApi();
app.ConfigureComicEndpoint();
app.ConfigureUserEndpoint();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
