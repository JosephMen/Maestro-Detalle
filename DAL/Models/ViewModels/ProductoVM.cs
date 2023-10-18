namespace DAL.Models.ViewModels;
public class ProductoVM
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public int Precio { get; set; }
    public string? PictureUrl { get; set; }
    public string? PictureType { get; set; }
    public int Stock { get; set; }
}
