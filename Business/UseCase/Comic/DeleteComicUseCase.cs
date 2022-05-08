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

namespace Business.UseCase
{
    public class DeleteComicUseCase : BaseUseCase<DeleteComicDTO, Result<bool>>
    {
        private readonly IComicRepository comicRepository;

        public DeleteComicUseCase(IComicRepository comicRepository)
        {
            this.comicRepository = comicRepository;
        }

        public override async Task<Result<bool>> Execute(DeleteComicDTO p)
        {
            try
            {
                await comicRepository.DeleteComic(p);
                return Result.Ok(true);
            } catch (Exception ex)
            {
                return Result.Fail<bool>(new ErrorModel(ErrorCodes.GeneralError));
            }
        }
    }
}
