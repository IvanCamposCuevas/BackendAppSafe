//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BackSafe.AccesoDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class EMPRESA
    {
        public EMPRESA()
        {
            this.CONTRATO = new HashSet<CONTRATO>();
            this.TRABAJADOR = new HashSet<TRABAJADOR>();
        }
    
        public short USUARIO_ID { get; set; }
        public string NOMBRE_EMPRESA { get; set; }
        public string RUN_EMPRESA { get; set; }
    
        public virtual ICollection<CONTRATO> CONTRATO { get; set; }
        public virtual USUARIO USUARIO { get; set; }
        public virtual ICollection<TRABAJADOR> TRABAJADOR { get; set; }
    }
}