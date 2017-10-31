using System;
using System.Data;
using System.Web.UI.WebControls;
using xs_System.Logic;
using xsFramework.Web.WebPage;
using xsFramework.UserControl.Pager;

namespace xs_System.Page.P_System
{
    public partial class User : AuthWebPage
    {

        UserLogic pageLogic = new UserLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                xsPage.StartShowPage();
                DataTable dtGroup = pageLogic.QueryUserGroup();
                ddlGroup.DataSource = dtGroup;
                ddlGroup.DataTextField = "group_name";
                ddlGroup.DataValueField = "group_id";
                ddlGroup.DataBind();
                ddlGroup.Items.Insert(0, new ListItem("全部", ""));

                ddlType.DataSource = dtGroup;
                ddlType.DataTextField = "group_name";
                ddlType.DataValueField = "group_id";
                ddlType.DataBind();

                txtUserid.Attributes.Add("readonly", "true");
            }
        }



        protected void btnQuery_Click(object sender, EventArgs e)
        {
            xsPage.StartShowPage();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DirModel dml = new DirModel();
            dml.Add("@userid", (sender as Button).CommandArgument);
            dml.Add("@opertateUser", LoginUser.LoginUser);
            if (pageLogic.DeleteUser(dml))
            {
                AlertMessage("删除用户成功!");

            }
            else
            {
                AlertMessage("删除用户失败!");
            }
            xsPage.RefreshPage();


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DirModel dml = new DirModel();
            dml.Add("@userid", txtUserid.Text);
            dml.Add("@userName", txtUserName.Text);
            dml.Add("@usergroup", ddlType.SelectedValue.Trim());
            dml.Add("@opertateUser", LoginUser.LoginUser);
            if (pageLogic.UpdateUser(dml))
            {
                AlertMessage("更新用户成功！");
            }
            else
            {
                AlertMessage("更新用户失败！");
            }
            xsPage.RefreshPage();
        }

        protected void xsPage_PageChanged(object sender, PageChangedEventArgs e)
        {
            PagerParameter pagepara = new PagerParameter();
            pagepara.DbConn = GlabalString.DBString;
            pagepara.XsPager = xsPage;
            pagepara.Sql = pageLogic.QueryUser(ddlGroup.SelectedValue);
            pagepara.OrderBy = "group_id";

            if (!"G001".Equals(LoginUser.LoginUserGroup))
            {
                gvUser.Columns[2].Visible = false;
            }
            gvUser.DataSource = xsPageHelper.BindPager(pagepara, e);
            gvUser.DataBind();

        }
    }
}