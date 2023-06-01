using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogRepository.Modelos
{
    public class ModelRequestProducto
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public string? filter { get; set; }
        public int? filterType { get; set; }
        public string? orderBy { get; set; }
    }
}
