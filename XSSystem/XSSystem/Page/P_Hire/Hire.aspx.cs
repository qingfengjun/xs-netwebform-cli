using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xs_System.Logic;
using xsFramework.Web.WebPage;
using xsFramework.UserControl.Pager;

namespace xs_System.Page.P_Hire
{
    public partial class Hire : AuthWebPage
    {
        HireLogic pageLogic = new HireLogic();
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
            dml.Add("@hire_id", (sender as Button).CommandArgument);
            if (pageLogic.DeleteHire(dml))
            {
                AlertMessage("删除成功!");

            }
            else
            {
                AlertMessage("删除失败!");
            }
            xsPage.RefreshPage();
        }

        protected void xsPage_PageChanged(object sender, xsFramework.UserControl.Pager.PageChangedEventArgs e)
        {
            PagerParameter pagepara = new PagerParameter();
            pagepara.DbConn = GlabalString.DBString;
            pagepara.XsPager = xsPage;
            pagepara.Sql = pageLogic.QueryHire();
            pagepara.OrderBy = "hire_id";

            gvhire.DataSource = xsPageHelper.BindPager(pagepara, e);
            gvhire.DataBind();
        }
    }
}