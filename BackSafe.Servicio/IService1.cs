using BackSafe.Entidad;
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
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        List<EntUsuario> retornarUsuarios();

        [OperationContract]
        List<EntTipoEvaluacion> retornarTiposEvaluacion();

        [OperationContract]
        Boolean crearTipoEvaluacion(string descripcion);

        [OperationContract]
        Boolean crearUsuario(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                            string direccion, decimal telefono, string email, decimal idPerfil);

        [OperationContract]
        bool modificarUsuario(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                            string direccion, decimal telefono, string email, decimal idPerfil);

        [OperationContract]
        bool crearVisitaMedica(DateTime fecVisita, decimal idContrato, decimal idMedico);
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
