using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackSafe.Entidad;

namespace BackSafe.Negocio
{
    public class PerfilUsuarios : AccesoConexion
    {

        public List<EntPerfilUsuario> obtenerPerfilUsuario()
        {
            Conexion.IntruccioneSQL = "fn_VerPerfilUsuario";
            Conexion.retornarDatosFunciones();
            List<EntPerfilUsuario> listaPerfilUsuario = new List<EntPerfilUsuario>();
            foreach (DataRow item in Conexion.DbDat.Tables[Conexion.NombreTabla].Rows)
            {
                listaPerfilUsuario.Add(new EntPerfilUsuario(item["id"].ToString(), item["descripcion_perfil"].ToString()));
            }
            return listaPerfilUsuario;
        }


    }
}

