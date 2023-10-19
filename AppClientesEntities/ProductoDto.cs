using System;

namespace SistemaGestionEntities
{

    public class ProductoDto
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public string Costo { get; set; }

        public string PrecioVenta { get; set; }

        public string Stock { get; set; }

        public string IdUsuario { get; set; }
    }

}