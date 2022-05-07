using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Editorial
    {
        public int EditorialId { get; set; }
        public string Name { get; set; }

        public Editorial()
        {
            this.EditorialId = 0;
            this.Name = string.Empty;
        }

        public Editorial(int editorialId, string name)
        {
            this.EditorialId = editorialId;
            this.Name = name;
        }

    }
}
