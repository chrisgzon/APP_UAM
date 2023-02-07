using APP_UAM.Entities.Usuario;
using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_UAM.Repository.Usuarios
{
    public class UsuariosRepository
    {
        public async Task<List<Usuario>> Listar()
        {
            try
            {
                string Query = "SELECT IdUsuario, Nombres FROM USUARIOS;";
                string stringConnection = Conexion.GetConnection();
                using (SqlConnection ctx = new SqlConnection(stringConnection))
                {
                    IEnumerable<Usuario> result = await ctx.QueryAsync<Usuario>(Query);
                    return result.ToList();
                }
            }
            catch (Exception)
            {
                return new List<Usuario>();
            }
        }
    }
}