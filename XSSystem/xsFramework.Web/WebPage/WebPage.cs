using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using xsFramework.Web.Login;

namespace xsFramework.Web.WebPage
{
    public class WebPage : Page
    {
        #region login message
        public LoginModel LoginUser
        {
            get
            {
                if (Session["LoginModel"] != null)
                {
                    return (LoginModel)Session["LoginModel"];
                }
                else { return null; }
            }
        }
        #endregion

        #region javascript
        /// <summary>
        /// 提示错误信息
        /// </summary>
        /// <param name="script"></param>
        public void AlertMessage(string script)
        {
            base.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script type='text/javascript'>alert('" + script + "');</script>");
        }


        /// <summary>
        /// 提示错误信息并跳到相应页面
        /// </summary>
        /// <param name="MsgStr"></param>
        /// <param name="toUrl"></param>
        public void AlertMessageAndGoTo(string MsgStr, string toUrl)
        {
            base.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script type='text/javascript'>alert('" + MsgStr + "');window.location.href='" + toUrl + "';</script>");

        }
        /// <summary>
        /// 后台运行javascript
        /// </summary>
        /// <param name="script"></param>
        public void JavaScript(string script)
        {
            base.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "<script type='text/javascript'>" + script + "</script>");
        }
        #endregion
    }
}
