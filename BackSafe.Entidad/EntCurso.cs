using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSafe.Entidad
{
    public class EntCurso
    {
        public string id { get; set; }
        public string descripcion { get; set; }
        public string idCapac { get; set; }

        public EntCurso()
        {

        }

        public EntCurso(string id, string desc, string idCapac)
        {
            this.id = id;
            this.descripcion = desc;
            this.idCapac = idCapac;
        }
    }
}
