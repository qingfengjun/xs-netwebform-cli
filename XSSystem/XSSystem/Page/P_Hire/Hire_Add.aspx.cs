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
    public partial class Hire_Add : AuthWebPage
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

            DataTable dtTemp = pageLogic.QueryHireTemplate();
            Session["HireTemplateAdd"] = dtTemp;
            ddlType.DataSource = dtTemp;
            ddlType.DataTextField = "hire_template_name";
            ddlType.DataValueField = "hire_template_id";
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("空白模板", ""));
        }
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType.SelectedValue.Length > 0)
            {
                DataTable dtTemp = Session["HireTemplateAdd"] as DataTable;
                DataRow[] drselect = dtTemp.Select("hire_template_id=" + ddlType.SelectedValue);
                if (drselect.Length > 0)
                {
                    txtRemark.Text = drselect[0]["hire_template_content"].ToString();
                }
            }
            else
            {
                txtRemark.Text = "";
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtRemark.Text.Trim().Length == 0)
            {
                AlertMessage("内容不能为空"); return;
            }
            DirModel dml = new DirModel();
            string strHireNo = "H" + DateTime.Now.ToString("yyyyMMddHHssmmm");
            dml.Add("@hire_id", strHireNo);
            dml.Add("@hire_name", txtName.Text);
            dml.Add("@hire_count", txtCount.Text);
            dml.Add("@hire_place", txtPlace.Text);
            dml.Add("@hire_remark", txtRemark.Text);
            if (pageLogic.AddHire(dml))
            {
                AlertMessageAndGoTo("招聘发布成功", "/Page/P_Hire/Hire.aspx");
            }
            else
            {
                AlertMessage("招聘发布失败");
            }
        }
    }
}