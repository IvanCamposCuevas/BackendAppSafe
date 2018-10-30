using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSafe.Entidad
{
    
    public class EntContrato
    {
        public string  id{ get; set; }
        public string descContrato { get; set; }
        public string fechaInicioContrato { get; set; }
        public string estado { get; set; }
        public string empresaId { get; set; }

        public EntContrato()
        {

        }

        public EntContrato(string id, string descripcion, string fecInicio, string estado, string empresaId)
        {
            this.id = id;
            this.descContrato = descripcion;
            this.fechaInicioContrato = fecInicio;
            this.estado = estado;
            this.empresaId = empresaId;
        }


    }
}
