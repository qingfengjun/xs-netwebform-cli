using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xs_System.Logic;
using xsFramework.Web.WebPage;
namespace xs_System.Page.P_System
{
    public partial class User_Add : AuthWebPage
    {
        UserLogic pageLogic = new UserLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                DataTable dtGroup = pageLogic.QueryUserGroup();
                ddlGroup.DataSource = dtGroup;
                ddlGroup.DataTextField = "group_name";
                ddlGroup.DataValueField = "group_id";
                ddlGroup.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DirModel dml = new DirModel();
            dml.Add("@userid", txtUserid.Text);
            if (pageLogic.ExistUser(dml))
            {
                AlertMessage("用户已经存在！");
                return;
            }
            dml.Add("@userName", txtUserName.Text);
            dml.Add("@userpassword", txtPassword.Text);
            dml.Add("@usergroup", ddlGroup.SelectedValue.Trim());
            dml.Add("@opertateUser", LoginUser.LoginUser);
            if (pageLogic.AddUser(dml))
            {
                AlertMessageAndGoTo("新增成功！", "/Page/P_System/User.aspx");
            }
            else
            {
                AlertMessage("新增失败！");
            }
        }
    }
}