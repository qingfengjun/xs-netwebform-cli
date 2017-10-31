using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xs_System.Logic;
using xsFramework.Web.WebPage;
using xsFramework.UserControl.Pager;
using System.Data;

namespace xs_System.Page.P_News
{
    public partial class News_Query : AuthWebPage
    {
        newsLogic pageLogic = new newsLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlNewType.DataSource = pageLogic.QueryNewType();
                ddlNewType.DataTextField = "new_type_name";
                ddlNewType.DataValueField = "new_type_id";
                ddlNewType.DataBind();
                xsPage.StartShowPage();
            }


        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = sender as LinkButton;
            DirModel dml = new DirModel();
            dml.Add("@new_id", lbtn.CommandName.Trim());

            if (pageLogic.DeleteNew(dml))
            {
                AlertMessage("删除成功！");
                xsPage.RefreshPage();
            }
            else
            {
                AlertMessage("删除失败！");

            }
        }

        protected void xsPage_PageChanged(object sender, xsFramework.UserControl.Pager.PageChangedEventArgs e)
        {
            PagerParameter pagepara = new PagerParameter();
            pagepara.DbConn = GlabalString.DBString;
            pagepara.XsPager = xsPage;
            pagepara.Sql = pageLogic.QueryNews(ddlNewType.SelectedValue,txtNewName.Text.Trim());
            pagepara.OrderBy = "new_id";

            DataTable dt = xsPageHelper.BindPager(pagepara, e);
            Nodata.Visible = false;
            if (dt.Rows.Count == 0) Nodata.Visible = true;

            rptNews.DataSource = dt;
            rptNews.DataBind();
        }

        protected void ddlNewType_SelectedIndexChanged(object sender, EventArgs e)
        {
            xsPage.StartShowPage();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            xsPage.RefreshPage();
        }
    }
}