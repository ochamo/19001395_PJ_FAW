using Business.Repository;
using Infrastructure;
using Infrastructure.Model;
using Infrastructure.Result;

namespace Business.UseCase
{
    public class GetSexesUseCase : BaseUseCase<None, Result<IEnumerable<SexModel>>>
    {
        private readonly ISexRepository sexRepository;

        public GetSexesUseCase(ISexRepository sexRepository)
        {
            this.sexRepository = sexRepository;
        }

        public override async Task<Result<IEnumerable<SexModel>>> Execute(None p)
        {
            try
            {
                var result = await sexRepository.GetSexModels();
                return Result.Ok(result);
            } catch(Exception ex)
            {
                return Result.Fail<IEnumerable<SexModel>>(new ErrorModel(ErrorCodes.SexesNotLoaded));
            }
        }
    }
}
