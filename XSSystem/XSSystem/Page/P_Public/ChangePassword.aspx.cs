using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xsFramework.Web.WebPage;
using xs_System.Logic;
namespace XSSystem.Page.P_Public
{
    public partial class ChangePassword : WebPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!txtOldPassword.Text.Equals(LoginUser.LoginUserPassword))
            {
                AlertMessage("请输入正确密码！");
                return;
            }
            if (txtNewPassword.Text != txtAgain.Text)
            {
                AlertMessage("二次输入密码不一致！");
                return;
            }
            DirModel dml = new DirModel();
            dml.Add("@user_password", txtAgain.Text);
            dml.Add("@user_no", LoginUser.LoginUser);
            UserLogic pageLogic = new UserLogic();
            if (pageLogic.ChangeUserPassword(dml))
            {
                if (Request.Cookies["xsCookie"] != null)
                {
                    HttpCookie cok = Request.Cookies["xsCookie"];
                    TimeSpan ts = new TimeSpan(-1, 0, 0, 0);
                    cok.Expires = DateTime.Now.Add(ts);//删除整个Cookie，只要把过期时间设置为现在
                }
                AlertMessage("密码修改成功，需要重新登录才能生效.");
            }
        }
    }
}