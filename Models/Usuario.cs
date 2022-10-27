using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PreEntregaPF.Models
{
    public class Usuario
    {
        #region Staments

        private int _Id;
        private string _Nombre;
        private string _Apellido;
        private string _NombreUsuario;
        private string _Contraseña;
        private string _Mail;
        #endregion

        #region Builders
        public int Id { get { return _Id; } set { _Id = value; } }
        public string Nombre { get { return _Nombre; } set { _Nombre = value.TrimEnd().ToUpper(); } }
        public string Apellido { get { return _Apellido; } set { _Apellido = value.TrimEnd().ToUpper(); } }
        public string NombreUsuario { get { return _NombreUsuario; } set { _NombreUsuario = value.TrimEnd().ToUpper(); } }
        public string Contraseña { get { return _Contraseña; } set { _Contraseña = value.TrimEnd().ToUpper(); } }
        public string Mail { get { return _Mail; } set { _Mail = value.TrimEnd().ToUpper(); } }
        #endregion
        public List<ProductoVendido> ProductoVendidos { get; set; }
        public Usuario ()
        {

        }

        public Usuario (int id, string nombre, string apellido, string nombreUsuario, string contraseña, string mail)
        {
            Id = id;
            Nombre = nombre;    
            Apellido = apellido;
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
            Mail = mail;

        }


    }
}
