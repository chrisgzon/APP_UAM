using APP_UAM.Interfaces.Carro;

namespace APP_UAM.Entities.Carro
{
    internal class Carro : ICarro
    {
        public int IdCarro { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string UltimoKilometraje { get; set; } = "0";
        public string ValorVehiculo { get; set; } = "0";
        public string Marca { get; set; } = string.Empty;
        public int CantidadAsientos { get; set; } = 0;
        public DateTime FechaCompra { get; set; }
    }
}