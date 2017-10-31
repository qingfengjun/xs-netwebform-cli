using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xs_System.Logic;
using xsFramework.UserControl.Pager;
using System.Data;
using xsFramework.Web.WebPage;

namespace xs_System.Page.P_Product
{
    public partial class Product : AuthWebPage
    {
        ProductLogic pageLogic = new ProductLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlType.DataSource = pageLogic.QueryProductType();
                ddlType.DataTextField = "product_type_name";
                ddlType.DataValueField = "product_type_id";
                ddlType.DataBind();
                xsPage.StartShowPage();
            }
        }

        protected void xsPage_PageChanged(object sender, xsFramework.UserControl.Pager.PageChangedEventArgs e)
        {
            PagerParameter pagepara = new PagerParameter();
            pagepara.DbConn = GlabalString.DBString;
            pagepara.XsPager = xsPage;
            pagepara.Sql = pageLogic.QueryProducts(ddlType.SelectedValue, txtName.Text);
            pagepara.OrderBy = "product_id";

            DataTable dt = xsPageHelper.BindPager(pagepara, e);
            Nodata.Visible = false;
            if (dt.Rows.Count == 0) Nodata.Visible = true;

            rptProduct.DataSource = dt;
            rptProduct.DataBind();
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            DirModel dml = new DirModel();
            dml.Add("@product_id", (sender as LinkButton).CommandArgument);
            if (pageLogic.DeleteProduct(dml))
            {
                AlertMessage("删除成功.");
                xsPage.RefreshPage();
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            xsPage.RefreshPage();
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            xsPage.RefreshPage();
        }

    }
}