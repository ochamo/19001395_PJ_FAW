using Business.Repository;
using Infrastructure;
using Infrastructure.DTO;
using Infrastructure.Model;
using Infrastructure.Result;

namespace Business.UseCase.Comic
{
    public class CreateComicUseCase : BaseUseCase<CreateComicDTO, Result>
    {
        private readonly IComicRepository comicRepository;

        public CreateComicUseCase(IComicRepository comicRepository)
        {
            this.comicRepository = comicRepository;
        }

        public override async Task<Result> Execute(CreateComicDTO p)
        {
            try
            {
                await comicRepository.CreateComic(p);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(new ErrorModel(ErrorCodes.GeneralError));
            }
        }
    }
}
