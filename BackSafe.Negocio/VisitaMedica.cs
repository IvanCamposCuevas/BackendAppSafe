using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BackSafe.Negocio
{
    public class VisitaMedica : AccesoConexion
    {
        public bool crearVisitaMedica(DateTime fecVisita, decimal idContrato, decimal idMedico)
        {
            Conexion.IntruccioneSQL = "por_crearvisita";
            return Conexion.conectarProcCrearVisita(fecVisita, idContrato, idMedico);
        }

    }
}
