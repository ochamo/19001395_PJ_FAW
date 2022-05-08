using Business.Repository;
using DataAccess.DBAccess;
using DataAccess.Entity;
using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class SexRepositoryImpl : ISexRepository
    {

        private readonly ISqlDataAccess db;

        public SexRepositoryImpl(ISqlDataAccess db)
        {
            this.db = db;
        }


        public async Task<IEnumerable<SexModel>> GetSexModels()
        {
            var models = await db.LoadData<Sex, dynamic>(Procedures.GetSexes, new { });

            return models.Select(p => new SexModel { SexId = p.SexId, Description = p.Description });

        }
    }
}
