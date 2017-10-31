using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using xs_System.Logic;

namespace XSSystem.Page.P_News
{
    public partial class New : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["id"] != null)
                {
                    newsLogic pageLogic = new newsLogic();
                    DataTable dt = pageLogic.QueryNewByID(Request["id"].ToString());
                    if (dt.Rows.Count != 0)
                    {

                        lblTitle.Text = dt.Rows[0]["new_title"].ToString();
                        lblContent.Text = dt.Rows[0]["new_content"].ToString();

                    }
                }
            }
        }
    }
}