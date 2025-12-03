using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CncApp_Final.Entities
{
    public enum SupplierType
    {
        [Description("انبار")]
        Warehouse = 0,

        [Description("مشتری")]
        Customer = 1
    }
}
