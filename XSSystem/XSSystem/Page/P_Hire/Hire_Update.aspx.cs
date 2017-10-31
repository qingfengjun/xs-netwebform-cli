using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xs_System.Logic;
using xsFramework.Web.WebPage;

namespace xs_System.Page.P_Hire
{
    public partial class Hire_Update : AuthWebPage
    {
        HireLogic pageLogic = new HireLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                InitData();
            }
        }
        private void InitData()
        {

            string strHireNo = Request["id"].ToString();
            DirModel dml = new DirModel();
            dml.Add("@hire_id", strHireNo);
            DataTable dtHire = pageLogic.QueryHire(dml);
            if (dtHire.Rows.Count > 0)
            {
                txtName.Text = dtHire.Rows[0]["hire_name"].ToString();
                txtCount.Text = dtHire.Rows[0]["hire_count"].ToString();
                txtPlace.Text = dtHire.Rows[0]["hire_place"].ToString();
                txtRemark.Text = dtHire.Rows[0]["hire_remark"].ToString();

            }
            else
            {
                AlertMessage("数据异常");
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (txtRemark.Text.Trim().Length == 0)
            {
                AlertMessage("内容不能为空"); return;
            }
            DirModel dml = new DirModel();
            string strHireNo = Request["id"].ToString();
            dml.Add("@hire_id", strHireNo);
            dml.Add("@hire_name", txtName.Text);
            dml.Add("@hire_count", txtCount.Text);
            dml.Add("@hire_place", txtPlace.Text);
            dml.Add("@hire_remark", txtRemark.Text);
            if (pageLogic.UpdateHire(dml))
            {
                AlertMessageAndGoTo("修改成功", "/Page/P_Hire/Hire.aspx");
            }
            else
            {
                AlertMessage("修改失败");
            }
        }
    }
}