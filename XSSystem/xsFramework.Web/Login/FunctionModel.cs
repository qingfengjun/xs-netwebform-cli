using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xsFramework.Web.Login
{
   public class FunctionModel
    {
        private string functionUrl = "";

        public string FunctionUrl
        {
            get { return functionUrl; }
            set { functionUrl = value; }
        }
        private string functionActions = "";

        public string FunctionActions
        {
            get { return functionActions; }
            set { functionActions = value; }
        }
    }
}
