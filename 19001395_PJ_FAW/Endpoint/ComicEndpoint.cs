using Business.UseCase;
using Business.UseCase.Comic;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;

namespace _19001395_PJ_FAW.Endpoint
{
    public static class ComicEndpoint
    {
        public static void ConfigureComicEndpoint(this WebApplication app)
        {
            app.MapGet("/Comic/{lastId}", GetComics).RequireAuthorization();
            app.MapPost("/Comic/", CreateComic).RequireAuthorization();
            app.MapPut("/Comic/{comicId}", UpdateComic).RequireAuthorization();
            app.MapDelete("/Comic/{comicId}", DeleteComic).RequireAuthorization();
        }

        private static async Task<IResult> GetComics(int lastId, GetComicsUseCase getComicsUseCase)
        {
            var result = await getComicsUseCase.Execute(new GetComicsDTO(lastId));

            if (result.Success)
            {
                return Results.Ok(result.Value);
            } else
            {
                return Results.Problem(JsonSerializer.Serialize(result.Error));
            }

        }

        private static async Task<IResult> CreateComic([FromHeader(Name = "Authorization")] string authorization, CreateComicDTO p, CreateComicUseCase createComicUseCase)
        {

            var token = authorization.Replace("Bearer ", "");
            var jwtHandler = new JwtSecurityTokenHandler();
            var jsonToken = jwtHandler.ReadToken(token) as JwtSecurityToken;
            var id = jsonToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
            p.UserId = int.Parse(id);

            var result = await createComicUseCase.Execute(p);

            if (result.Success)
            {
                return Results.Ok(result);
            } else
            {
                return Results.Problem(JsonSerializer.Serialize(result.Error));
            }

        }

        private static async Task<IResult> UpdateComic(int comicId, UpdateComicDTO p, UpdateComicUseCase updateComicUseCase)
        {
            var result = await updateComicUseCase.Execute(p);
            if (result.Success)
            {
                return Results.Ok(result);
            } else
            {
                return Results.Problem(JsonSerializer.Serialize(result.Error));
            }
        }

        private static async Task<IResult> DeleteComic(int comicId, DeleteComicUseCase deleteComicUseCase)
        {
            var dto = new DeleteComicDTO()
            {
                ComicId = comicId,
            };
            var result = await deleteComicUseCase.Execute(dto);
            if (result.Success)
            {
                return Results.Ok(result.Value);
            } else 
            {
                return Results.Problem(JsonSerializer.Serialize(result.Error));
            } 
        }

    }
}
