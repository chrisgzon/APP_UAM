using APP_UAM.Entities.Usuario;
using APP_UAM.Repository.Usuarios;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace APP_UAM.Logic
{
    public static class Login
    {
        public static async Task<Usuario?> SetLogin(Usuario usuario)
        {
			try
			{
				string password = Transversales.convertirSha256(usuario.Clave);
				Usuario user = await new UsuariosRepository().GetUsuarioLogin(usuario.Correo);
				if (user.Clave == password)
				{
					return user;
				}
				return null;
			}
			catch (Exception)
			{
				return null;
			}
        }
    }
}
