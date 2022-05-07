using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class User
    {
        public int UserId { get; set; }

        public int SexId { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }
        public string Pass { get; set; }

        public DateTime BirthDate { get; set; }

        public User()
        {
            this.UserId = 0;
            this.SexId = 0;
            this.UserName = string.Empty;
            this.Name = string.Empty;
            this.Pass = string.Empty;
            this.BirthDate = DateTime.Now;
        }

        public User(int userId, int sexId, string userName, string name, string pass, DateTime birthDate)
        {
            this.UserId = userId;
            this.SexId = sexId;
            this.UserName = userName;
            this.Name = name;
            this.Pass = pass;
            this.BirthDate = DateTime.Now;
        }

    }
}
