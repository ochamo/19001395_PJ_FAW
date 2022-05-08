using Business.UseCase;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json;

namespace _19001395_PJ_FAW.Endpoint
{
    public static class SexApi
    {
        public static void ConfigureSexApi(this WebApplication app)
        {
            app.MapGet("/Sex", GetSexes).RequireAuthorization();
        }

        private static async Task<IResult> GetSexes(GetSexesUseCase getSexesUseCase)
        {
            var result = await getSexesUseCase.Execute(new None());

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
