using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xsFramework.Web.Login
{
    /// <summary>
    /// 登录Model
    /// </summary>
    public class LoginModel
    {
        private string loginUser = "";

        public string LoginUser
        {
            get { return loginUser; }
            set { loginUser = value; }
        }
        private string loginUserName = "";

        public string LoginUserName
        {
            get { return loginUserName; }
            set { loginUserName = value; }
        }
        private string loginUserPassword = "";

        public string LoginUserPassword
        {
            get { return loginUserPassword; }
            set { loginUserPassword = value; }
        }

        private string loginUserGroup = "G000";

        public string LoginUserGroup
        {
            get { return loginUserGroup; }
            set { loginUserGroup = value; }
        }
        private string loginUserGroupName = "一般使用者";

        public string LoginUserGroupName
        {
            get { return loginUserGroupName; }
            set { loginUserGroupName = value; }
        }

        private List<FunctionModel> functions = new List<FunctionModel>();

        public List<FunctionModel> Functions
        {
            get { return functions; }
        }

        public void AddFunction(string functionUrl,string functionAction)
        {
            FunctionModel fm = new FunctionModel();
            fm.FunctionActions = functionAction;
            fm.FunctionUrl = functionUrl;
            functions.Add(fm);
        }

    }
}
