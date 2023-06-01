using CatalogRepository.Entidades;
using CatalogRepository.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogRepository.Repositorios
{
    public class ProductoRepository : IProductoRepository
    {
        CatalogContext _context;
        public ProductoRepository(CatalogContext context)
        {
            this._context = context;
        }
        public void Agregar(Producto producto)
        {
            try
            {
                _context.Producto.Add(producto);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Editar(Producto producto)
        {
            try
            {
                Producto? producto1 = _context.Producto.Where(x => x.Id == producto.Id).FirstOrDefault();
                if (producto1 != null)
                {
                    _context.Producto.Update(producto);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException("El producto a editar no existe.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Eliminar(int idProducto)
        {
            Producto? producto1 = _context.Producto.Where(x => x.Id == idProducto).FirstOrDefault();
            if (producto1 != null)
            {
                _context.Producto.Remove(producto1);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentNullException("El producto a eliminar no existe.");
            }
        }

        public List<Producto> Productos(ModelRequestProducto request)
        {
            try
            {
                List<Producto> products = new();
                request.filterType = request.filter == null ? 0 : request.filterType;
                switch (request.filterType)
                {
                    case 1:
                        products = _context.Producto.Where(x => x.Nombre.Contains(request.filter)).ToList();
                        break;
                    case 2:
                        products = _context.Producto.Where(x => x.Descripcion.Contains(request.filter)).ToList();
                        break;
                    case 3:
                        products = _context.Producto.Where(x => x.Categoria.Contains(request.filter)).ToList();
                        break;
                    case 0:
                        products = _context.Producto.ToList();
                        break;
                }
                string[]? orderByField = !string.IsNullOrWhiteSpace(request.orderBy) ? request.orderBy.Split(',') : null;
                if (orderByField != null)
                {

                    switch (orderByField[0])
                    {
                        case "1":
                            products = orderByField[1].Equals("asc") ? products.OrderBy(x => x.Nombre).ToList() : products.OrderByDescending(x => x.Nombre).ToList();
                            break;
                        case "2":
                            products = orderByField[1].Equals("asc") ? products.OrderBy(x => x.Descripcion).ToList(): products.OrderByDescending(x => x.Descripcion).ToList();
                            break;
                        case "3":
                            products = products.OrderBy(x => x.Categoria).ToList();
                            break;
                    }
                }
                if (request.page != 0)
                {
                    products = products.Skip((request.page - 1) * request.pageSize).Take(request.pageSize).ToList();
                }
                return products;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
