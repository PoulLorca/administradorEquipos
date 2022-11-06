using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipo_Negocio
{
    public class IsValidNombreDT : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool res = true;
            int len = value.ToString().Length;
            int min = 5;
            int max = 30;

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
