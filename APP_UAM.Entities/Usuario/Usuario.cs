using APP_UAM.Interfaces.Usuario;

namespace APP_UAM.Entities.Usuario
{
    public class Usuario : IUsuario
    {
        public int IdUsuario { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
