using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BackSafe.Entidad;
namespace BackSafe.Servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicioAppEscritorio" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicioAppEscritorio
    {
        [OperationContract]
        List<EntUsuario> retornarUsuarios();

        [OperationContract]
        List<EntEmpresa> retornarEmpresas();

        [OperationContract]
        List<EntContrato> retornarContratos();


        [OperationContract]
        List<EntTipoEvaluacion> retornarTiposEvaluacion();

        [OperationContract]
        List<EntPerfilUsuario> retornarPerfilUsuarios();

        [OperationContract]
        Boolean crearTipoEvaluacion(string descripcion);

        [OperationContract]
        bool modificarTipoEvaluacion(decimal id_tipoeval, string descripcion);

        [OperationContract]
        bool eliminarTipoEvaluacion(string descevaluacion);

        [OperationContract]
        bool eliminarEmpresa(string rutempresa);

        [OperationContract]
        bool eliminarUsuario(string rut);

        [OperationContract]
        Boolean crearUsuario(string rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                            string direccion, decimal telefono, string email, decimal idPerfil, decimal idEmpresa);

        [OperationContract]
        Boolean crearEmpresa(string nomEmpresa, string runEmpresa, string dirEmpresa, decimal telEmpresa, string corEmpresa);

        [OperationContract]
        bool modificarEmpresa(decimal idEmpresa, string nomEmpresa, string runEmpresa, string dirEmpresa, decimal telEmpresa, string corEmpresa);

        [OperationContract]
        bool modificarUsuario(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                            string direccion, decimal telefono, string email);
      

        [OperationContract]
        EntUsuario login(string rut, string contraseña);

        [OperationContract]
        bool crearUsuarioMedico(string rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                    string direccion, decimal telefono, string email, decimal idPerfil, decimal idEmpresa, string disponibilidad, string mailPrivado, decimal telefonoPriv);
        [OperationContract]
        bool crearUsuarioTrabajador(string rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                    string direccion, decimal telefono, string email, decimal idPerfil, decimal idEmpresa, string mailPrivado, decimal telPrivado,
                                    string estadoRiesgo, decimal contratoId);

        [OperationContract]
        string descContraseña(string rut);
    }
}
