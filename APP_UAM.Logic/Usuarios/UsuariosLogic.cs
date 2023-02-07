using APP_UAM.Entities.Usuario;
using APP_UAM.Repository.Usuarios;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_UAM.Logic.Usuarios
{
    public class UsuariosLogic
    {
        private UsuariosRepository _repository;
        public UsuariosLogic()
        {
            _repository= new UsuariosRepository();
        }
        public async Task<List<Usuario>> Listar()
        {
            try
            {
                return await _repository.Listar();
            }
            catch (Exception)
            {
                return new List<Usuario>();
            }
        }
    }
}
