using DAL.Models;

namespace WebSite.Models
{
    public class DetalleCrear
    {
        public int idCompra { get; set; }
        public List<Producto> productos { get; set; } = new();
        public DetalleCompra detalle { get; set; } = new();
    }
}
