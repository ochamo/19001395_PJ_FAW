using Business.Repository;
using Infrastructure;
using Infrastructure.DTO;
using Infrastructure.Model;
using Infrastructure.Result;


namespace Business.UseCase.Comic
{
    public class GetComicsUseCase : BaseUseCase<GetComicsDTO, Result<IEnumerable<ComicModel>>>
    {
        private readonly IComicRepository comicRepository;

        public GetComicsUseCase(IComicRepository comicRepository)
        {
            this.comicRepository = comicRepository;
        }

        public override async Task<Result<IEnumerable<ComicModel>>> Execute(GetComicsDTO p)
        {
            try
            {
                var result = await comicRepository.GetComics(p);
                return Result.Ok(result);
            } catch (Exception ex)
            {
                return Result.Fail<IEnumerable<ComicModel>>(new ErrorModel(ErrorCodes.GeneralError));
            }
        }
    }
}
