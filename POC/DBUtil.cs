using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POC
{
    public static class DBUtil
    {
        public static C Convert<C>(object value)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (System.Convert.IsDBNull(value)) return default(C);
            return (C)value;
        }
    }
}
