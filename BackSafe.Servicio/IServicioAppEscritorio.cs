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
        List<EntTipoEvaluacion> retornarTiposEvaluacion();

        [OperationContract]
        List<EntPerfilUsuario> retornarPerfilUsuarios();

        [OperationContract]
        Boolean crearTipoEvaluacion(string descripcion);

        [OperationContract]
        bool modificarTipoEvaluacion(decimal id_tipoeval, string descripcion);

        [OperationContract]
        bool eliminarTipoEvaluacion(decimal id_tipoeval);

        [OperationContract]
        bool eliminarEmpresa(decimal run_empresa);

        [OperationContract]
        Boolean crearUsuario(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                            string direccion, decimal telefono, string email, decimal idPerfil);

        [OperationContract]
        Boolean crearEmpresa(decimal usuarioId, string nomEmpresa, string runEmpresa);

        [OperationContract]
        bool modificarEmpresa(decimal usuarioId, string nomEmpresa, string runEmpresa);

        [OperationContract]
        bool modificarUsuario(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                            string direccion, decimal telefono, string email, decimal idPerfil);
      

        [OperationContract]
        string login(decimal rut, string contraseña);

        [OperationContract]
        bool crearUsuarioMedico(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                    string direccion, decimal telefono, string email, decimal idPerfil, string disponibilidad, string mailPrivado, decimal telefonoPriv);
        [OperationContract]
        bool crearUsuarioTrabajador(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                    string direccion, decimal telefono, string email, decimal idPerfil, string mailPrivado, decimal telPrivado,
                                    string estadoRiesgo, decimal contratoId, decimal empresaId);
    }
}
