using System;

namespace MiProyecto
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string NombreUsuario { get; set; }

        public string Contraseña { get; set; }

        public string Mail { get; set; }
    }

    public class Producto
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public string Costo { get; set; }

        public string PrecioVenta { get; set; }

        public string Stock { get; set; }

        public string IdUsuario { get; set; }
    }

    public class ProductoVendido
    {
        public int Id { get; set; }

        public string IdProducto { get; set; }

        public string Stock { get; set; }

        public string IdVenta { get; set; }

    }

    public class Venta
    {
        public int Id { get; set; }

        public string Comentarios { get; set; }

        public string IdUsuario { get; set; }

    }

}