
namespace DAL.Models.ViewModels
{
    public class CompraVM
    {
        public string? NumeroDocumento { get; set; }
        public string? Razon { get; set; }
        public HashSet<DetalleCompraVM> DetalleCompras { get; set; } = new HashSet<DetalleCompraVM>();
    }
}
