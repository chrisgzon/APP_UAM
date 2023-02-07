using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_UAM.Repository
{
    internal class Conexion
    {
        private const string DbconexTFS = "Data Source={0};User ID={1};Password={2};Initial Catalog={3};Connection Timeout=20;MultipleActiveResultSets=True";
        private const string Password = "D@v1d*21";
        private const string User = "sa";
        public static string Server = @"DESKTOP-TERFBNJ\MSSQLSERVER2019";
        public static string Database = "DB_UAM";
        public static string GetConnection()
        {
            var strconex = string.Format(DbconexTFS, Server, User, Password, Database);
            return strconex;
        }
    }
}
