using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Equipo_GUI.Validations
{
    public class NombreDTCustomRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string val = value as string;
            int len = val.Length;
            int min = 5;
            int max = 30;

            if (len <= min || len >= max)
            {
                return new ValidationResult(false, "Nombre del equipo debe ser entre " + min + "  y " + max + "carácteres");
            }

            return new ValidationResult(true, null);
        }
    }
    
}
