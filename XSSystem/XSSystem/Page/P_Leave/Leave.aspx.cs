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
namespace xs_System.Page.P_Leave
{
    public partial class Leave :AuthWebPage 
    {
        LeaveLogic pageLogic = new LeaveLogic();
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
            string strID = (sender as LinkButton).CommandArgument.Length == 0 ? "0" : (sender as LinkButton).CommandArgument;
            dml.Add("@leave_id", Convert.ToInt32(strID));
            if (pageLogic.DeleteLeave(dml))
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
            pagepara.Sql = pageLogic.QueryLeave();
            pagepara.OrderBy = "leave_time";
            DataTable dt = xsPageHelper.BindPager(pagepara, e);
            NoData.Visible = false;
            if (dt.Rows.Count == 0)
            {
                NoData.Visible = true;
            }
            else
            {
                rptLeave.DataSource = dt;
                rptLeave.DataBind();
            }
            
        }
    }
}