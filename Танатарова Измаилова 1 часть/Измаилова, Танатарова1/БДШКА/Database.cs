using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace БДШКА
{
    public class Database
    {
        private string connectionString =
            "Server=192.168.227.14;Port=3306;Database=tradeddr;Uid=user07;Pwd=User07!Pass;";
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
