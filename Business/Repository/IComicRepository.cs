using Infrastructure.DTO;
using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public interface IComicRepository
    {
        public Task<IEnumerable<ComicModel>> GetComics(GetComicsDTO getComicsDTO);

        public Task DeleteComic(DeleteComicDTO deleteComicDTO);

        public Task UpdateComic(UpdateComicDTO updateComicDTO);

        public Task CreateComic(CreateComicDTO createComicDTO);

    }
}
