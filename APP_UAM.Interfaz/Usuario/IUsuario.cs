namespace APP_UAM.Interfaces.Usuario
{
    public interface IUsuario
    {
        int IdUsuario { get; }
        string Nombres { get; }
        string Apellidos { get; }
        string Correo { get; }
        string Clave { get; }
        bool Activo { get; }
        DateTime FechaRegistro { get; }
    }
}
