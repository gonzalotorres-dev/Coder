using MiProyecto;
using System.Collections.Generic;
using static AppClientesData.ProductData;
using static AppClientesData.UsersData;
using static AppClientesData.SalesData;
using static AppClientesData.ProductSoldData;

namespace AppClientesBusiness
{
    public class BusinessService
    {
        public static class ProductoBusiness
        {
            public static Producto ObtenerProductoPorId(int id)
            {
                return GetProductById(id);
            }

        }

        public static class UsuarioBusiness
        {
            public static Usuario ObtenerUsuarioPorId(int id)
            {
                return GetUserById(id);
            }

        }

        public static class VentaBusiness
        {
            public static Venta ObtenerVentaPorId(int id)
            {
                return GetSalesById(id);
            }

        }

        public static class ProductoVendidoBusiness
        {
            public static ProductoVendido ObtenerProductoVendidoPorId(int id)
            {
                return GetProductSalesById(id);
            }

        }
    }
}