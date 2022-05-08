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
    public class LoginUseCase : BaseUseCase<LoginDTO, Result<LoginModel>>
    {
        private readonly IUserRepository userRepository;

        public LoginUseCase(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public override async Task<Result<LoginModel>> Execute(LoginDTO p)
        {
            try
            {
                var result = await userRepository.login(p);
                return Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail<LoginModel>(new ErrorModel(ErrorCodes.UserNotFound));
            }
        }
    }
}
