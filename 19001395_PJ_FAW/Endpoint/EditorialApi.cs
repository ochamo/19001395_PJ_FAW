using Business.UseCase;
using Infrastructure;
using System.Text.Json;

namespace _19001395_PJ_FAW.Endpoint
{
    public static class EditorialApi
    {
        public static void ConfigureEditorialApi(this WebApplication app)
        {
            app.MapGet("/Editorial", GetEditorials).RequireAuthorization();
        }

        private static async Task<IResult> GetEditorials(GetEditorialsUseCase getEditorialsUseCase)
        {
            var result = await getEditorialsUseCase.Execute(new None());

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
