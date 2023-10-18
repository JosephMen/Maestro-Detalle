namespace DAL.Models;
public partial class Compra
{
    public int Id { get; set; }
    public string? NumeroDocumento { get; set; }
    public string? Razon { get; set; }
    public decimal? Total { get; set; }
    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();
}
