using PreEntregaPF.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

    public class ProductoRepository
    {
        public  List<Producto> TraerProductoPorUsuario(int usuarioid)
        {
            var list = new List<Producto>();

            SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = "TR-D0B1M13\\SQL2019",
                InitialCatalog = "SistemaGestion",
                IntegratedSecurity = true,
            };
            var conStr = connectionBuilder.ConnectionString;

            using (var oConn = new SqlConnection(conStr))
            {
                oConn.Open();

                var query = $"Select * From Producto where IdUsuario = {usuarioid}"; 

                var oCmd = new SqlCommand(query, oConn);

                using (var oDr = oCmd.ExecuteReader())
                {
                    if (oDr.HasRows)
                    {
                        while (oDr.Read())
                        {
                            var productos = new Producto();
                                productos.Id = (int)oDr.GetInt64(0);
                                productos.Descripciones = oDr.GetString(1);
                                productos.Costo = oDr.GetDouble(2);
                                productos.PrecioVenta = oDr.GetDouble(3);
                                productos.Stock = oDr.GetInt32(4);
                                productos.IdUsuario = oDr.GetInt32(5);
                                list.Add(productos);
                        }
                    }
                }
                oConn.Close();
            }
        return list;
        }

    }

