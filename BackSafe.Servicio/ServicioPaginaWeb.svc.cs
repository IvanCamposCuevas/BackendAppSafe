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
    // NOTA: puede usar el comando "Rename" del men� "Refactorizar" para cambiar el nombre de clase "Service1" en el c�digo, en svc y en el archivo de configuraci�n.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuraci�n.

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

        public bool crearVisitaMedica(string fecVisita, decimal idEmpresa, decimal idMedico)
        {
            return new VisitaMedica().crearVisitaMedica(fecVisita, idEmpresa, idMedico);
        }

        public DataSet login(string rut, string contraseña)
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

        public bool crearPlanCapacitacion(string descripcion, int idEmpresa, string fechaPlan)
        {
            return new Supervisor().crearPlanCapacitacion(descripcion, idEmpresa, fechaPlan);
        }

        public bool crearCapacitacion(string descCapacitacion, decimal minParticipantes, string nomExpositor, string fecInicial, string fecFinal, int idPlanCapac)
        {
            return new Supervisor().crearCapacitacion(descCapacitacion, minParticipantes, nomExpositor, fecInicial, fecFinal, idPlanCapac);
        }

        public bool crearEvaluacion(string fecEval, string descEval, decimal tipoEvalId, decimal empresaId, decimal usuarioId)
        {
            return new Tecnico().crearEvaluacion(fecEval, descEval, tipoEvalId, empresaId, usuarioId);
        }

        public DataSet retornarTipoEvaluacion()
        {
            return new TiposEvaluacion().obtenerTipoEvaluacionDs();
        }

        public DataSet retornarMedicos()
        {
            return new Medico().obtenerMedico();
        }

        public DataSet retornarEmpresas()
        {
            return new Empresas().obtenerEmpresasDs();
        }

        public DataSet retornarEvaluacionesPorTecnico()
        {
            return new Tecnico().obtenerEvaluacionTecnico();
        }

        public DataSet retornarEvaluacionesPorIngeniero()
        {
            return new Ingeniero().obtenerEvaluacionesIngeniero();
        }

        public bool crearInformeIngeniero(string recomendacion, decimal usuarioId, decimal evalId)
        {
            return new Ingeniero().crearInformeEvaluacion(recomendacion, usuarioId, evalId);
        }

               
        public DataSet obtenerTipoExamen()
       
        {
            return new TipoExamen().obtenerTipoExamen();
            
        }
        public DataSet retornarInformes(decimal idEmpresa)
        {
            return new Supervisor().retornarInformesEvaluaciones(idEmpresa);
        }

        public bool crearAtencion(string desc_atencion, string rut, decimal id_visita_medica, string fechaAtencion)
        {
            return new Medico().crearAtencion(desc_atencion, rut, id_visita_medica, fechaAtencion);
        }

        public bool crearExamen(string desc_examen, string f_examen, decimal id_tipo_examen, decimal id_atencion)
        {
            return new Medico().crearExamen(desc_examen, f_examen, id_tipo_examen, id_atencion);
        }

        public DataSet retornarEvaluacionesSupervisor(decimal idEmpresa)
        {
            return new Supervisor().retornarEvaluacionesSupervisor(idEmpresa);
        }

        public bool actualizarEstadoEvaluacion(decimal idEvaluacion, int estadoEval, string motivo)
        {
            return new Supervisor().actualizarEstadoEvaluacion(idEvaluacion, estadoEval, motivo);
        }

        public bool crearCurso(string descripcion, decimal idCapac)
        {
            return new Supervisor().crearCurso(descripcion, idCapac);
        }

        public DataSet retornarCapacitaciones()
        {
            return new Supervisor().obtenerCapacitciones();
        }

        public DataSet retornarPlanCapacitaciones()
        {
            return new Supervisor().obtenerPlanCapacitacion();
        }

        public DataSet retornarVisitasMedicasPorEmpresa(decimal idEmpresa)
        {
            return new VisitaMedica().retornarVisitaMedicaPorEmpresa(idEmpresa);
        }

        public DataSet retornarConsulta(string rut)
        {
            return new AccesoMedico().retornarConsulta(rut);
        }
    }
}
