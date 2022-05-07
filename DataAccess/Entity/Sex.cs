using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class Sex
    {
        public int SexId { get; set; }
        public string Description { get; set; }
        
        public Sex()
        {
            this.SexId = 0;
            this.Description = string.Empty;
        }

        public Sex(int sexId, string description)
        {
            this.SexId = sexId;
            this.Description = description;
        }

    }
}
