using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.ViewModels
{
    public class CompraMostrarVM
    {
        public int Id { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Razon { get; set; }
        public decimal? Total { get; set; }
    }
}
