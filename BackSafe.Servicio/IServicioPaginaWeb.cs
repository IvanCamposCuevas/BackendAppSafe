﻿using BackSafe.Entidad;
using BackSafe.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BackSafe.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioPaginaWeb
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);


        [OperationContract]
        bool crearVisitaMedica(DateTime fecVisita, decimal idContrato, decimal idMedico);

        [OperationContract]
        string login(string rut, string contraseña);

        [OperationContract]
        DataSet obtenerContratos();

        [OperationContract]
        DataSet obtenerCursos();

        [OperationContract]
        DataSet obtenerExamanes(decimal idAtencion);

        [OperationContract]
        DataSet obtenerVisitaPorId(decimal idMedico);

        [OperationContract]
        DataSet obtenerVisitaPorFecha(DateTime fecha);

        [OperationContract]
        bool crearPlanCapacitacion(string descripcion, int idEmpresa);
        [OperationContract]
        bool crearCapacitacion(string descCapacitacion, decimal minParticipantes, string nomExpositor, string fecInicial, string fecFinal, int idPlanCapac);
        [OperationContract]
        bool crerEvaluacion(string fecEval, string descEval, decimal tipoEvalId, decimal empresaId);
        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
