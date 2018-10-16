using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackSafe.AccesoDatos;
using System.Data.Objects;

namespace BackSafe.Negocio
{
    public class Curso
    {
        public Boolean crearCurso(string decCurso, decimal capacId)
        {
            using (EntitiesSafe acceso = new EntitiesSafe())
            {
                if (acceso.PR_CREARCURSO(decCurso, capacId) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public ObjectResult<CURSO> retornarListaCurso()
        {
            using(EntitiesSafe acceso = new EntitiesSafe())
            {
                return acceso.FN_VERCURSO();
            }
        }

        public Boolean crearListaCapacitacion (short[] idCapacitantes, short idCurso)
        {
            using (EntitiesSafe acceso = new EntitiesSafe())
            {
                foreach (short item in idCapacitantes)
                {
                    REGISTRO_PARTICIPANTES regpart = new REGISTRO_PARTICIPANTES();
                    regpart.TRABAJADOR_ID = item;
                    regpart.CURSO_ID = idCurso;
                    regpart.ESTADO = "I";
                    acceso.REGISTRO_PARTICIPANTES.Add(regpart);
                }
                acceso.SaveChanges();
                return true;
            }
        }
    }
}
