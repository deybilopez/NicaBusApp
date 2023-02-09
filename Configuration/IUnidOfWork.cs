using NicaBusMVC.Sevices;

namespace NicaBusMVC.Configuration
{
    public interface IUnidOfWork
    {
        IUserRepository UserRepository { get; }
        IDetalleViajeRepository DetalleViajeRepository { get; }
        IRutaRepository RutaRepository { get; }

        void commit();
        void Dispose();
    }
}
