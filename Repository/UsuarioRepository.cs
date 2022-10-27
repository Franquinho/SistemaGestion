using PreEntregaPF.Models;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace PreEntregaPF.Repository
{
    public class UsuarioRepository
    {
        #region Methods
        public Usuario TraerUsuario(string usuario)
        {
            Usuario usuarioConsulta = new Usuario();
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

                var query = $"Select * From Usuario where NombreUsuario = {usuario}";

                var oCmd = new SqlCommand(query, oConn);

                using (var oDr = oCmd.ExecuteReader())
                {
                    if (oDr.HasRows)
                    {
                        usuarioConsulta.Id = (int)oDr.GetInt32(0);
                        usuarioConsulta.Nombre = oDr.GetString(1);
                        usuarioConsulta.Apellido = oDr.GetString(2);
                        usuarioConsulta.NombreUsuario = oDr.GetString(3);
                        usuarioConsulta.Contraseña = oDr.GetString(4);
                        usuarioConsulta.Mail = oDr.GetString(5);
                    }

                }
                oConn.Close();


            }           
            return usuarioConsulta;

        }

        public Usuario LoguearUsuario(string usuario, string contraseña)
        {
            Usuario usuarioLogueado = new Usuario();
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

                var query = $"Select * From Usuario where NombreUsuario = {usuario} AND Contraseña = {contraseña}";

                var oCmd = new SqlCommand(query, oConn);

                using (var oDr = oCmd.ExecuteReader())
                {
                    if (oDr.HasRows)
                    {

                        usuarioLogueado.Id = (int)oDr.GetInt32(0);
                        usuarioLogueado.Nombre = oDr.GetString(1);
                        usuarioLogueado.Apellido = oDr.GetString(2);
                        usuarioLogueado.NombreUsuario = oDr.GetString(3);
                        usuarioLogueado.Contraseña = oDr.GetString(4);
                        usuarioLogueado.Mail = oDr.GetString(5);
                        oConn.Close();
                        return usuarioLogueado;
                    }
                    else
                        return new Usuario();
                }
            }
        }
        #endregion Methods
    }

}   