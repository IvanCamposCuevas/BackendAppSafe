using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackSafe.AccesoDatos;
using System.Runtime.Serialization;
namespace BackSafe.Negocio
{
    
    public class AccesoConexion
    {
        public AccesoConexion()
        {
            configuraConexion();
        }

        private ConexionBD conexion;
       
        
        /// <summary>
        /// Objeto de Clase Conexion que tiene los metodos GET Y SET incluidos.
        /// </summary>
        public ConexionBD Conexion
        {
            get { return conexion; }
            set { conexion = value; }
        }

        /// <summary>
        /// Clase que servira para instanciar la clase Conexion e incializar algunos de sus Objetos.
        /// </summary>
        private void configuraConexion()
        {
            this.Conexion = new ConexionBD();
            this.Conexion.NombreBaseDeDatos = "prueba";
            this.Conexion.NombreTabla = "clientes";

            this.Conexion.CadenaConexion = "DATA SOURCE=localhost:1521/xe;PASSWORD=1;USER ID=BD_SAFE";
        }
    }
}
