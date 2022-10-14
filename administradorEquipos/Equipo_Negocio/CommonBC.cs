using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipo_Negocio
{
    public class CommonBC
    {
        private static Equipo_DALC.PCEEntities _modeloEquipo;

        public static Equipo_DALC.PCEEntities ModeloEquipo
        {
            get
            {
                if (_modeloEquipo == null)
                {
                    _modeloEquipo = new Equipo_DALC.PCEEntities();
                }
                return _modeloEquipo;
            }
        }

        public CommonBC() { }

    }
}
