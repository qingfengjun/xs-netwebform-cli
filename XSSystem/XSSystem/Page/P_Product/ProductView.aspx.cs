using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xs_System.Logic;
using System.Data;

namespace XSSystem.Page.P_Product
{
    public partial class ProductView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Request["id"] != null)
                {
                    ProductLogic pageLogic = new ProductLogic();
                    DataTable dt = pageLogic.QueryProductByID(Request["id"].ToString());
                    if (dt.Rows.Count != 0)
                    {
                        lblRemark.Text = dt.Rows[0]["product_remark"].ToString();
                        lblTitle.Text = dt.Rows[0]["product_title"].ToString();
                        lblContent.Text = dt.Rows[0]["product_content"].ToString();

                    }
                }
            }
        }
    }
}