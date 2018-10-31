using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackSafe.Entidad
{
    public class EntEmpresa
    {
        public string idUsuario { get; set; }
        public string nomEmpresa { get; set; }
        public string runEmpresa { get; set; }

        public EntEmpresa()
        {
        }

        public EntEmpresa(string idUsuario, string nomEmpresa, string runEmpresa)
        {
            this.idUsuario = idUsuario;
            this.nomEmpresa = nomEmpresa;
            this.runEmpresa = runEmpresa;
        }

    }
}
