using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CncApp_Final.Helper
{
    // Implements a custom validation rule.
    public class CustomValidationRule : ValidationRule
    {
        public override bool Validate(Control control, object value)
        {
            if (value == null)
            {
                return false;
            }
            return true;
        }
    }
}
