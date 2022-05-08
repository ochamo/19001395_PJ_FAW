using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class GetComicsDTO
    {
        public int LastComicId { get; set; }

        public GetComicsDTO()
        {
            this.LastComicId = 0;
        }

        public GetComicsDTO(int lastComicId)
        {
            this.LastComicId = lastComicId;
        }

    }
}
