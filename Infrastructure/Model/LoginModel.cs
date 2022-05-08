using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public class LoginModel
    {
        public int UserId { get; set; }
        public int SexId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
    }
}
