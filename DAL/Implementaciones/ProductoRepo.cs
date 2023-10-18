using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementaciones
{
    public class ProductoRepo : GenericRepository<Producto>, IProductoRepo
    {
        private readonly AtomContext _context;
        public ProductoRepo(AtomContext context) : base(context)
        {
            _context = context;
        }

    }
}
