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
            int len = val.Length;

            if (len <= 8 || len >= 25)
            {
                return new ValidationResult(false, "Nombre del equipo debe ser entre 8 y 25 carácteres");
            }

            return new ValidationResult(true, null);
        }
    }
}
