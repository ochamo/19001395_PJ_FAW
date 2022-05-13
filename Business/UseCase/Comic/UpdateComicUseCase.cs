using Business.Repository;
using Infrastructure;
using Infrastructure.DTO;
using Infrastructure.Model;
using Infrastructure.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.UseCase.Comic
{
    public class UpdateComicUseCase : BaseUseCase<UpdateComicDTO, Result>
    {
        private readonly IComicRepository comicRepository;

        public UpdateComicUseCase(IComicRepository comicRepository)
        {
            this.comicRepository = comicRepository;
        }

        public override async Task<Result> Execute(UpdateComicDTO p)
        {
            try
            {
                await comicRepository.UpdateComic(p);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(new ErrorModel(ErrorCodes.GeneralError));
            }
        }
    }
}
