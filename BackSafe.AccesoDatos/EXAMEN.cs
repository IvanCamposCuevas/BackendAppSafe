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
    
    public partial class EXAMEN
    {
        public short ID { get; set; }
        public string DESCRIPCION { get; set; }
        public System.DateTime FECHA_EXAMEN { get; set; }
        public short TIPO_EXAMEN_ID { get; set; }
        public short ATENCION_ID { get; set; }
    
        public virtual ATENCION ATENCION { get; set; }
        public virtual TIPO_EXAMEN TIPO_EXAMEN { get; set; }
    }
}
