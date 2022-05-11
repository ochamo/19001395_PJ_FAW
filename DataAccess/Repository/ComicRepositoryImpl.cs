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
    public class ComicRepositoryImpl : IComicRepository
    {
        private readonly ISqlDataAccess db;

        public ComicRepositoryImpl(ISqlDataAccess db)
        {
            this.db = db;
        }

        public Task CreateComic(CreateComicDTO createComicDTO) => db.SaveData(Procedures.InsertComic, createComicDTO);

        public Task DeleteComic(DeleteComicDTO deleteComicDTO) => db.DeleteSingle(Procedures.DeleteComic, deleteComicDTO);

        public async Task<IEnumerable<ComicModel>> GetComics(GetComicsDTO getComicsDTO)
        {
            var comicEntities = await db.LoadData<Comic, GetComicsDTO>(Procedures.GetComics, getComicsDTO);
            return comicEntities.Select(p => new ComicModel() { UserId = p.UserId, ComicId = p.ComicId, IdEditorial = p.IdEditorial, Name = p.Name, PrintYear = p.PrintYear, Sinopsis = p.Sinopsis });
        }

        public Task UpdateComic(UpdateComicDTO updateComicDTO) => db.SaveData(Procedures.UpdateComic, updateComicDTO);
    }
}
