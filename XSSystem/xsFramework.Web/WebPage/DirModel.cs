using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xsFramework.Web.WebPage
{
    public class DirModel : Dictionary<string, object>
    {
        public T GetValue<T>(string key)
        {
            return (T)this[key];
        }
    }
}
