namespace APP_UAM.Interfaces.Carro
{
    public interface ICarro
    {
        int IdCarro { get; }
        string Placa { get; }
        string UltimoKilometraje { get; }
        string ValorVehiculo { get; }
        string Marca { get; }
        int CantidadAsientos { get; }
        DateTime FechaCompra { get; }
    }
}
