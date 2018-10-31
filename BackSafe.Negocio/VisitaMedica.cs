using System;
using System.Collections.Generic;
using System.Data;
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

        public DataSet retornarVisitaMedicaPorId(decimal idMedico)
        {
            Conexion.IntruccioneSQL = "fn_VerVisitasMedicas";
            Conexion.retornarDatosVisitaMedicaPorIdMedico(idMedico);

            return Conexion.DbDat;
        }

        public DataSet retornarVisitaMedicaPorFecha(DateTime fecha)
        {
            Conexion.IntruccioneSQL = "fn_VerVisitasMedicasPorFecha";
            Conexion.retornarVisitaMedicaPorFecha(fecha);

            return Conexion.DbDat;
        }
    }
}
