using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipo_Negocio
{
    public class Equipo : IPersistente
    {
        public int Id { get; set; }
        public string NombreEquipo { get; set; }
        public int CantidadJugadores { get; set; }
        public string NombreDt { get; set; }
        public string TipoEquipo { get; set; }
        public string CapitanEquipo { get; set; }
        public bool TieneSub21 { get; set; }

        public bool Create()
        {
            try
            {
                CommonBC.ModeloEquipo.spEquipoSave(
                this.NombreEquipo,
                this.CantidadJugadores,
                this.NombreDt,
                this.TipoEquipo,
                this.CapitanEquipo,
                this.TieneSub21
                );

                CommonBC.ModeloEquipo.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }

        }

        public bool Read(int EquipoId)
        {
            try
            {
                Equipo_DALC.vwEquipo equipo = CommonBC.ModeloEquipo.vwEquipo.First(e => e.EquipoId == EquipoId);

                this.NombreEquipo = equipo.NombreEquipo;
                this.CantidadJugadores = equipo.CantidadJugadores;
                this.NombreDt = equipo.NombreDT;
                this.TipoEquipo = equipo.TipoEquipo;
                this.CapitanEquipo = equipo.CapitanEquipo;
                this.TieneSub21 = equipo.TieneSub21;

                return true;

            }
            catch 
            {
                return false;
            }

        }

        public bool Update()
        {
            try
            {                                                
                CommonBC.ModeloEquipo.spEquipoUpdateById(
                    this.Id,
                    this.NombreEquipo,
                    this.CantidadJugadores,
                    this.NombreDt,
                    this.TipoEquipo,
                    this.CapitanEquipo,
                    this.TieneSub21
                    );

                CommonBC.ModeloEquipo.SaveChanges();

                return true;

            }
            catch 
            {
                return false;
            }
        }

        public bool Delete(int EquipoId)
        {
            try
            {
                CommonBC.ModeloEquipo.spEquipoDeleteById(EquipoId);
                CommonBC.ModeloEquipo.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
