using CatalogRepository.Entidades;
using CatalogRepository.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogRepository.Repositorios
{
    public interface IProductoRepository
    {
        public List<Producto> Productos(ModelRequestProducto request);
        public void Agregar(Producto producto);
        public void Editar(Producto producto);
        public void Eliminar(int idProducto);

    }
}
