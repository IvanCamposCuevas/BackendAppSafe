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
        public bool crearVisitaMedica(string fecVisita, decimal idEmpresa, decimal idMedico)
        {
            Conexion.IntruccioneSQL = "pr_crearvisita";
            return Conexion.conectarProcCrearVisita(fecVisita, idEmpresa, idMedico);
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
