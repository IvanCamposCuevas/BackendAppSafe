using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BackSafe.Negocio;
using System.Data;
using BackSafe.Entidad;

namespace BackSafe.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
   
    public class ServicioPaginaWeb : IServicioPaginaWeb
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public bool crearVisitaMedica(DateTime fecVisita, decimal idContrato, decimal idMedico)
        {
            return new VisitaMedica().crearVisitaMedica(fecVisita, idContrato, idMedico);
        }

        public string login(string rut, string contraseña)
        {
            return new Usuarios().retornarLogin(rut, contraseña);
        }

        public DataSet obtenerContratos()
        {
            return new Contrato().retornarTodosLosContratos();
        }

        public DataSet obtenerCursos()
        {
            return new Curso().retornarCursos();
        }

        public DataSet obtenerExamanes(decimal idAtencion) => new Examen().retornarListaExamenes(idAtencion);

        public DataSet obtenerVisitaPorId(decimal idMedico) => new VisitaMedica().retornarVisitaMedicaPorId(idMedico);

        public DataSet obtenerVisitaPorFecha(DateTime fecha) => new VisitaMedica().retornarVisitaMedicaPorFecha(fecha);

        public bool crearPlanCapacitacion(string descripcion, int idEmpresa)
        {
           return new Supervisor().crearPlanCapacitacion(descripcion, idEmpresa);
        }

        public bool crearCapacitacion(string descCapacitacion, decimal minParticipantes, string nomExpositor, string fecInicial, string fecFinal, int idPlanCapac)
        {
            return new Supervisor().crearCapacitacion(descCapacitacion, minParticipantes, nomExpositor, fecInicial, fecFinal, idPlanCapac);
        }

        public bool crerEvaluacion(string fecEval, string descEval, decimal tipoEvalId, decimal empresaId)
        {
            return new Tecnico().crearEvaluacion(fecEval, descEval, tipoEvalId, empresaId);
        }
    }
}
