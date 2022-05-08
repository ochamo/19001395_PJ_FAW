using Business.Repository;
using DataAccess.DBAccess;
using DataAccess.Entity;
using Infrastructure.DTO;
using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly ISqlDataAccess db;

        public UserRepositoryImpl(ISqlDataAccess db)
        {
            this.db = db;
        }

        public Task createUser(CreateUserDTO userDTO) => db.SaveData(Procedures.InsertUser, userDTO);

        public async Task<LoginModel> login(LoginDTO loginDTO)
        {
            var result = await db.Single<User, LoginDTO>(Procedures.LoginUser, loginDTO);

            return new LoginModel() { Name = result.Name, Pass = result.Pass, SexId = result.SexId, UserId = result.UserId, UserName = result.UserName};

        }
    }
}
