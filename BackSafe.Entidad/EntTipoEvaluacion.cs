using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSafe.Entidad
{
public class EntTipoEvaluacion
    {
        public string id_tipoeval { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }

        public EntTipoEvaluacion()
        {
        }

        public EntTipoEvaluacion(string id_tipoeval, string descripcion, string estado)
        {
            this.id_tipoeval = id_tipoeval;
            this.descripcion = descripcion;
            this.estado = estado;
        }


    }
}
