using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Equipo_GUI.Validations
{
    public class CantidadJugadoresCustomRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string val = value as string;
            int len = int.Parse(val) ;
            int min = 16;
            int max = 25;

            if (len <= min || len >= max)
            {
                return new ValidationResult(false, "Nombre del equipo debe ser entre "+ min + "  y "+ max + "carácteres");
            }

            return new ValidationResult(true, null);
        }
    }
}
