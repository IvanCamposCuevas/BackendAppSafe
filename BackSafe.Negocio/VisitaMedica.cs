using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackSafe.AccesoDatos;
namespace BackSafe.Negocio
{
    public class VisitaMedica
    {
        public Boolean crearPlanMedico(DateTime fecVisita, decimal idContrato, decimal idMedico)
        {
            using (EntitiesSafe acceso = new EntitiesSafe())
            {
                if (acceso.PR_CREARVISITA(fecVisita, idContrato, idMedico) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Boolean crearExamen(string descExamen, DateTime fecExamen, decimal idTipoExamen, decimal idAtencion)
        {
            using (EntitiesSafe acceso = new EntitiesSafe())
            {
                if (acceso.PR_CREAREXAMEN(descExamen, fecExamen, idTipoExamen, idAtencion) > 0)
                {
                    return true;
                }else
                {
                    return false;
                }
            }
        }


    }
}
