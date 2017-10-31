using System;
using System.Web.UI.WebControls;
using xs_System.Logic;
using xsFramework.Web.WebPage;
using xsFramework.UserControl.Pager;

namespace xs_System.Page.P_System
{
    public partial class Group : AuthWebPage
    {
        groupLogic pageLogic = new groupLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                xsPage.StartShowPage();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DirModel dml = new DirModel();
            dml.Add("@group_id", (sender as Button).CommandArgument);
            if (pageLogic.DeleteGroup(dml))
            {
                AlertMessage("删除群组成功!");

            }
            else
            {
                AlertMessage("删除群组失败!");
            }
            xsPage.RefreshPage();
        }

        protected void gvGroup_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Button btnDelete = e.Row.Cells[3].FindControl("btnDelete") as Button;
                if ("G000".Equals(btnDelete.CommandArgument))
                {
                    btnDelete.Visible = false;
                }
            }
        }

        protected void xsPage_PageChanged(object sender, xsFramework.UserControl.Pager.PageChangedEventArgs e)
        {
            PagerParameter pagepara = new PagerParameter();
            pagepara.DbConn = GlabalString.DBString;
            pagepara.XsPager = xsPage;
            pagepara.Sql = pageLogic.QueryGroup();
            pagepara.OrderBy = "group_id";

            gvGroup.DataSource = xsPageHelper.BindPager(pagepara, e);
            gvGroup.DataBind();
        }



    }
}