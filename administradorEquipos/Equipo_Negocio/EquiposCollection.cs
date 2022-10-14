using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipo_Negocio
{
    public class EquiposCollection
    {
        public List<Equipo> ReadAll()
        {
            var equipos = CommonBC.ModeloEquipo.vwEquipo;
            return ObtenerEquipos(equipos.ToList());
        }

        private List<Equipo> ObtenerEquipos(List<Equipo_DALC.vwEquipo> equiposDALC)
        {
            List<Equipo> equiposList = new List<Equipo>();
            foreach (Equipo_DALC.vwEquipo equipo in equiposDALC)
            {
                Equipo e = new Equipo();
                e.Id = equipo.EquipoId;
                e.NombreEquipo = equipo.NombreEquipo;
                e.CantidadJugadores = equipo.CantidadJugadores;
                e.NombreDt = equipo.NombreDT;
                e.TipoEquipo = equipo.TipoEquipo;
                e.CapitanEquipo = equipo.CapitanEquipo;
                e.TieneSub21 = equipo.TieneSub21;

                equiposList.Add(e);
            }
            return equiposList;
        }
    }
}
