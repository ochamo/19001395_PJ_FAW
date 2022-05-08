using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public class ComicModel
    {
        public int ComicId { get; set; }
        public string Name { get; set; }
        public int IdEditorial { get; set; }

        public string PrintYear { get; set; }

        public string Sinopsis { get; set; }

    }
}
