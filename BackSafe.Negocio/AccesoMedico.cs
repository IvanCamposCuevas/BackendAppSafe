using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSafe.Negocio
{
    public class AccesoMedico : AccesoConexion
    {
        public string consulta()
        {
            string consulta = "SELECT u.rut_usuario AS Rut,"
                            + "u.nombre AS Nombre,"
                            + "u.ape_paterno || ' ' || u.ape_materno AS Apellidos,"
                            + "fm.estatura AS Estatura,"
                            + "fm.peso AS Peso,"
                            + "al.descipcion AS Alergia,"
                            //+ "fm.grupo_sanguineo AS Grupo Sanguineo,"
                            + "tb.telefono_privado AS Sede,"
                            + "tb.email_privado AS Mail,"
                            + "tb.estado_riesgo "
                            + "\n"
                            + " FROM "
                            + " JOIN trabajador tb ON u.id = tb.usuario_id "
                            + " JOIN ficha_medica fm ON tb.usuario_id = fm.trabajador_usuario_id "
                            + " JOIN registro_alergia ra ON fm.id = ra.ficha_medica_id "
                            + " JOIN alergia al ON ra.alergia_id = al.id";
           return consulta;

        }

        /// <summary>
        /// Metodo que sirva para buscar a un trabajador en especifico, 
        /// ya sea tanto por el nombre o el rut 
        /// </summary>
        /// <param name="rn"></param>
        /// <param name="valorTipo"></param>
        /// <returns></returns>
        public DataSet consultaTrabajadorPorRutNombre(String rn, String valorTipo)
        {
            String auxSQL = String.Empty;

            //Aplicar Filtros
            if (!String.IsNullOrEmpty(rn) && valorTipo.Equals("1"))
                auxSQL = auxSQL + " AND u.rut_usuario = '" + rn + "'";
            else
            {
                auxSQL = auxSQL + " AND u.nombre COLLATE Latin1_General_CI_AI LIKE '%" + rn + "%' COLLATE Latin1_General_CI_AI";
            }
            /*
             * Se crea y se reesguardan las intrucciones SQL dentro de la Clase Conexion.cs, 
             * tambien se agrega la variable auxiliar creada anteriormente
            */
            Conexion.IntruccioneSQL = consulta() + auxSQL + " ORDER BY Nombre ASC";

            Conexion.EsSelect = true; //Si la query es de consulta (SELECT...) se ingresa como True.
            Conexion.conectar(); //Se inicia la conexion con la query anteriormente ingresada.

            return Conexion.DbDat; //Se retornan los datos en un DataSet.
        } // Fin metodo entrega
    }
}
