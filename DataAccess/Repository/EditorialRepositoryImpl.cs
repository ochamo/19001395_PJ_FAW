
using Business.Repository;
using DataAccess.DBAccess;
using DataAccess.Entity;
using Infrastructure.Model;

namespace DataAccess.Repository
{
    public class EditorialRepositoryImpl : IEditorialRepository
    {

        private readonly ISqlDataAccess db;

        public EditorialRepositoryImpl(ISqlDataAccess db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<EditorialModel>> GetEditorials()
        {
            var editorials = await db.LoadData<Editorial, dynamic>(Procedures.GetEditorials, new {});

            return editorials.Select(it => new EditorialModel { EditorialId = it.EditorialId, Name = it.Name });

        }
    }
}
