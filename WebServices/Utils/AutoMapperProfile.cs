using System.Globalization;
using DAL;
using AutoMapper;
using DAL.Models.ViewModels;
using DAL.Models;

namespace WebServices.Utils
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() { 
            CreateMap<Compra, CompraVM>().ReverseMap();
            CreateMap<Compra, CompraActualizarVM>().ReverseMap();
            CreateMap<Compra, CompraMostrarVM>();
            CreateMap<Producto, ProductoVM>().ReverseMap();
            CreateMap<DetalleCompra, DetalleCompraVM>().ReverseMap();
            CreateMap<DetalleCompra, DetalleActualizarVM>().ReverseMap();
            CreateMap<DetalleCompra, DetalleMostrarVM>()
                .ForMember(dest => dest.Producto, opt => opt.MapFrom(src => src.IdProductoNavigation));
        }

    }
}
