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
    public partial class HireTemplate : AuthWebPage
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
            Session["HireTemplate"] = dtTemp;
            ddlType.DataSource = dtTemp;
            ddlType.DataTextField = "hire_template_name";
            ddlType.DataValueField = "hire_template_id";
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("新增模板", "add"));
            btnDelete.Visible = false;
            txtName.Text = "";
            txtTemplate.Text = "";
            hidType.Value = "add";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if ("modify".Equals(hidType.Value))
            {
                //modify
                DirModel dml = new DirModel();
                dml.Add("@hire_template_id", Convert.ToInt32(ddlType.SelectedValue));
                if (pageLogic.DeleteHireTemplate(dml))
                {
                    AlertMessage("模板删除成功");
                    InitData();

                }
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType.SelectedValue.Equals("add"))
            {
                btnDelete.Visible = false;
                txtName.Text = "";
                txtTemplate.Text = "";
                hidType.Value = "add";
            }
            else
            {
                btnDelete.Visible = true;
                hidType.Value = "modify";
                txtName.Text = ddlType.SelectedItem.Text;
                DataTable dtTemp = Session["HireTemplate"] as DataTable;
                DataRow[] drselect = dtTemp.Select("hire_template_id=" + ddlType.SelectedValue);
                if (drselect.Length > 0)
                {
                    txtTemplate.Text = drselect[0]["hire_template_content"].ToString();
                }
                //绑定数据
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length == 0) { AlertMessage("请输入模板内容!"); return; }
            if (txtTemplate.Text.Trim().Length == 0) { AlertMessage("请输入模板内容!"); return; }

            if (ddlType.SelectedValue.Equals("add"))
            {
                DirModel dml = new DirModel();
                dml.Add("@hire_template_name", txtName.Text);
                dml.Add("@hire_template_content", txtTemplate.Text);
                if (pageLogic.AddHireTemplate(dml))
                {
                    AlertMessage("模板更新成功");
                    InitData();

                }
            }
            else
            {
                DirModel dml = new DirModel();
                string strNo = ddlType.SelectedValue;
                dml.Add("@hire_template_id", Convert.ToInt32(ddlType.SelectedValue));
                dml.Add("@hire_template_name", txtName.Text);
                dml.Add("@hire_template_content", txtTemplate.Text);
                if (pageLogic.UpdateHireTemplate(dml))
                {
                    AlertMessage("模板更新成功");
                    InitData();
                    ddlType.SelectedValue = strNo;
                    ddlType_SelectedIndexChanged(null,null);
                }
                else
                {
                    AlertMessage("模板更新失败");
                }
            }
        }

    }
}