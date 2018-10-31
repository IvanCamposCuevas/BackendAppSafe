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
        Boolean crearUsuario(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                            string direccion, decimal telefono, string email, decimal idPerfil);

        [OperationContract]
        bool modificarUsuario(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                            string direccion, decimal telefono, string email, decimal idPerfil);
        // Acceso a al Servicio, Crear un usuario de tipo empresa.
        [OperationContract]
        Boolean crearUsuarioEmpresa(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                            string direccion, decimal telefono, string email, decimal idPerfil, string nomEmpresa, string runEmpresa);

        [OperationContract]
        string login(decimal rut, string contraseña);

        [OperationContract]
        bool crearEmpresa(decimal usuarioId, string nomEmpresa, string runEmpresa);
    }
}
