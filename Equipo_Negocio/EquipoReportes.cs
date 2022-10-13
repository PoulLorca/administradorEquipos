using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipo_Negocio
{
    public class EquipoReportes
    {
        public int ReporteEquiposFemeninos()
        {
            return Convert.ToInt32(CommonBC.ModeloEquipo.spObtenerCantidadEquiposFemeninos());
        }

        public int ReporteEquiposMasculinos()
        {
            return Convert.ToInt32(CommonBC.ModeloEquipo.spObtenerCantidadEquiposMasculinos());
        }
    }
}
