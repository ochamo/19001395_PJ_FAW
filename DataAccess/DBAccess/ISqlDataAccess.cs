using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, P>(string sql, P parameters, string connectionId = "Default");

        Task SaveData<T>(string sql, T data, string connectionId = "Default");

    }
}
