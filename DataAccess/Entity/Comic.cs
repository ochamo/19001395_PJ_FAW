using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Comic
    {
        public int ComicId { get; set; }
        public string Name { get; set; }
        public int IdEditorial { get; set; }

        public string PrintYear { get; set; }

        public string Sinopsis { get; set; }


        public Comic()
        {
            this.ComicId = 0;
            this.Name = string.Empty;
            this.IdEditorial = 0;
            this.PrintYear = string.Empty;
            this.Sinopsis = string.Empty;
        }

        public Comic(int comicId, int idEditorial, string name, string printYear, string sinopsis)
        {
            this.ComicId = comicId;
            this.IdEditorial = idEditorial;
            this.Name = name;
            this.PrintYear = printYear;
            this.Sinopsis = sinopsis;
        }

    }
}
