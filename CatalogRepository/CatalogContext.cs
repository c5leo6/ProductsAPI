using Microsoft.EntityFrameworkCore;
using CatalogRepository.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogRepository
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> opciones) : base (opciones)
        {

        }
        public DbSet<Producto> Producto { get; set; }
    }
}
