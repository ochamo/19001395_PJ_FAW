using Infrastructure.DTO;
using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public interface IUserRepository
    {
        public Task<LoginModel> login(LoginDTO loginDTO);

        public Task createUser(CreateUserDTO userDTO);

    }
}
