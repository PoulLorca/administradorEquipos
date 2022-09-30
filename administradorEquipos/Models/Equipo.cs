using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administradorEquipos.Models
{
    public class Equipo
    {
        public string NombreEquipo { get; set; } = null!;
        public int CantidadJugadores { get; set; }
        public string NombreDt { get; set; } = null!;
        public string TipoEquipo { get; set; } = null!; 
        public string CapitanEquipo { get; set; } = null!; 
        public bool TieneSub21 { get; set; }

        public Equipo()
        {
        }

        public Equipo(string nombreEquipo, int cantidadJugadores, string nombreDt, string tipoEquipo, string capitanEquipo, bool tieneSub21)
        {
            NombreEquipo = nombreEquipo;
            CantidadJugadores = cantidadJugadores;
            NombreDt = nombreDt;
            TipoEquipo = tipoEquipo;
            CapitanEquipo = capitanEquipo;
            TieneSub21 = tieneSub21;
        }        


    }
}
