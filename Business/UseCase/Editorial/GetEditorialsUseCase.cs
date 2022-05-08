using Business.Repository;
using Infrastructure;
using Infrastructure.Model;
using Infrastructure.Result;

namespace Business.UseCase
{
    public class GetEditorialsUseCase : BaseUseCase<None, Result<IEnumerable<EditorialModel>>>
    {
        private readonly IEditorialRepository editorialRepository;

        public GetEditorialsUseCase(IEditorialRepository editorialRepository)
        {
            this.editorialRepository = editorialRepository;
        }

        public override async Task<Result<IEnumerable<EditorialModel>>> Execute(None p)
        {
           try
            {
                var result = await editorialRepository.GetEditorials();

                return Result.Ok(result);
            } catch (Exception ex)
            {
                return Result.Fail<IEnumerable<EditorialModel>>(new ErrorModel(ErrorCodes.EditorialsNotLoaded));
            }
        }
    }
}
