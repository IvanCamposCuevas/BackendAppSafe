﻿using System;
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

        public string login(decimal rut, string contraseña)
        {
            return new Usuarios().retornarLogin(rut, contraseña);
        }

        public List<EntContrato> obtenerContratos()
        {
            return new Contrato().retornarTodosLosContratos();
        }

        public List<EntCurso> obtenerCursos()
        {
            return new Curso().retornarCursos();
        }

        public List<object> obtenerExmanes(decimal idAtencion) => new Examen().retornarListaExamenes(idAtencion);
    }
}