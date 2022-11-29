using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfTestMailSender.ViewModel
{
    class DataValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                string t = Convert.ToString(value);
                return new ValidationResult(false, "Выберите елемент");
            }
            else
            {
                return new ValidationResult(true, null);
            }

        }


    }
}
