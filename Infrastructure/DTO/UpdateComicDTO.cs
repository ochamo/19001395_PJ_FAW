using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class UpdateComicDTO
    {
        public int IdComic { get; set; }
        public string ComicName { get; set; }
        public int ComicEditorial { get; set; }

        public string ComicPrintYear { get; set; }

        public string ComicSinopsis { get; set; }
    }
}
