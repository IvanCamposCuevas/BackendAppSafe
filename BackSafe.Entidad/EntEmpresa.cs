using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSafe.Entidad
{
    public class EntEmpresa
    {
        public string idEmpresa { get; set; }
        public string nomEmpresa { get; set; }
        public string runEmpresa { get; set; }
        public string dirEmpresa { get; set; }
        public string telEmpresa { get; set; }
        public string corEmpresa { get; set; }

        public EntEmpresa()
        {
        }

        public EntEmpresa(string idEmpresa, string nomEmpresa, string runEmpresa, string dirEmpresa, string telEmpresa, string corEmpresa)
        {
            this.idEmpresa = idEmpresa;
            this.nomEmpresa = nomEmpresa;
            this.runEmpresa = runEmpresa;
            this.dirEmpresa = dirEmpresa;
            this.telEmpresa = telEmpresa;
            this.corEmpresa = corEmpresa;
        }

    }
}
