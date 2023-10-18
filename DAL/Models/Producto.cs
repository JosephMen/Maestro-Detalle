namespace DAL.Models;
public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public int Precio { get; set; }
    public string? PictureUrl { get; set; }
    public string? PictureType { get; set; }
    public int Stock { get; set; }
    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();
}
