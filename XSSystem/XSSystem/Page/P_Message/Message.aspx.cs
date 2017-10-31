using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xsFramework.Web.WebPage;
using xs_System.Logic;
using System.Data;
namespace XSSystem.Page.P_Message
{
    public partial class Message : AuthWebPage
    {
        MessageLogic pagelogic = new MessageLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                InitData();
            }
        }
        private void InitData()
        {
            DataTable dt = pagelogic.QueryMainName();
            ddlType.DataSource = dt;
            ddlType.DataTextField = "main_name";
            ddlType.DataValueField = "main_id";
            ddlType.DataBind();
            ddlType_SelectedIndexChanged(null, null);

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            DirModel dml = new DirModel();
            dml.Add("main_id", ddlType.SelectedValue);
            dml.Add("main_content", txtRemark.Text);
            dml.Add("updateuser", LoginUser.LoginUserName);
            if (pagelogic.UpdateMain(dml))
            {
                AlertMessage("更新" + ddlType.SelectedItem.Text + "成功");
            }
            else
            {
                AlertMessage("更新" + ddlType.SelectedItem.Text + "失败");
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRemark.Text = pagelogic.QueryMainContent(ddlType.SelectedValue);
        }
    }
}