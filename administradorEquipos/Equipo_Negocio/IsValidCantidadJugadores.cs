using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipo_Negocio
{
    public class IsValidCantidadJugadores : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool res = true;
            int len = int.Parse(value.ToString());
            int min = 16;
            int max = 25;            

            if (!string.IsNullOrEmpty(value.ToString()))
            {
                if (len <= min || len >= max)
                {
                    res = false;
                }
                else
                {
                    res = true;

                }
            }
            return res;
        }
    }
}
