using PreEntregaPF.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using PreEntregaPF.Repository;

namespace PreEntregaPF.Repository
{
    public class ProductoVendidoRepository
    {
        public  List<ProductoVendido> TraerProductosVendidos(int usuarioid)
        {
            List<ProductoVendido> listProductosVendidos = new List<ProductoVendido>();
            List<Producto> listProductos = new ProductoRepository().TraerProductoPorUsuario(usuarioid);

            SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "TR-D0B1M13\\SQL2019",
                InitialCatalog = "SistemaGestion",
                IntegratedSecurity = true,
            };
            var conStr = connectionBuilder.ConnectionString;

            using (var oConn = new SqlConnection(conStr))
            {
                foreach (Producto producto in listProductos)
                {
                    oConn.Open();

                    var query = $"Select * From ProductoVendido where idProducto = {producto.Id}";

                    var oCmd = new SqlCommand(query, oConn);

                    using (var oDr = oCmd.ExecuteReader())
                    {
                        if (oDr.HasRows)
                        {
                            while (oDr.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido();
                                productoVendido.Id = (int)oDr.GetInt32(0);
                                productoVendido.Stock = oDr.GetInt32(1);
                                productoVendido.IdProducto = oDr.GetInt32(2);
                                productoVendido.IdVenta = oDr.GetInt32(3);
                                listProductosVendidos.Add(productoVendido);
                            }
                        }
                    }
                    oConn.Close();
                }
                
            }
            return listProductosVendidos;
        }
    }
}
