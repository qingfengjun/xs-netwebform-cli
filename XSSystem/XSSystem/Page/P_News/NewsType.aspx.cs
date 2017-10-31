using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xsFramework.Web.WebPage;
using xs_System.Logic;
using System.Data;
namespace XSSystem.Page.P_News
{
    public partial class NewsType : AuthWebPage
    {
        newsLogic pageLogic = new newsLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindType();
            }
        }

        private void BindType()
        {
            DataTable dtType = pageLogic.QueryNewType();
            ddlType.DataSource = dtType;
            ddlType.DataTextField = "new_type_name";
            ddlType.DataValueField = "new_type_id";
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("新增动态类别", ""));
            btnDelete.Visible = false;
            txtRemark.Text = "";
            txtName.Text = "";
            btnSave.Text = "新增动态类别";
            Session["dtType"] = dtType;
        }
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlType.SelectedValue))
            {
                txtRemark.Text = "";
                txtName.Text = "";
                btnDelete.Visible = false;
                btnSave.Text = "新增动态类别";
            }
            else
            {
                if (Session["dtType"] != null)
                {
                    DataTable dtType = Session["dtType"] as DataTable;
                    DataRow[] drs = dtType.Select("new_type_id='" + ddlType.SelectedValue + "'");
                    if (drs.Length > 0)
                    {
                        txtRemark.Text = drs[0]["new_type_remark"].ToString();
                        txtName.Text = drs[0]["new_type_name"].ToString();
                        btnSave.Text = "更新动态类别";
                        btnDelete.Visible = true;

                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DirModel dml = new DirModel();

            dml.Add("@new_type_name", txtName.Text);
            dml.Add("@new_type_remark", txtRemark.Text);
            if (string.IsNullOrEmpty(ddlType.SelectedValue))
            {
                //新增
                dml.Add("@new_type_id", "NT" + DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                if (pageLogic.InsertNewType(dml))
                {
                    AlertMessage("新增" + txtName.Text + "成功");
                }
                else
                {
                    AlertMessage("新增" + txtName.Text + "失败，" + txtName.Text + "可能已经存在.");
                }
            }
            else
            {
                //维护
                dml.Add("@new_type_id", ddlType.SelectedValue);
                if (pageLogic.UpdateNewType(dml))
                {
                    AlertMessage("更新" + txtName.Text + "成功");
                }
                else
                {
                    AlertMessage("更新" + txtName.Text + "失败");
                }

            }
            BindType();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DirModel dml = new DirModel();
            string strText = ddlType.SelectedItem.Text;
            dml.Add("@new_type_id", ddlType.SelectedValue);
            if (pageLogic.DeleteNewType(dml))
            {
                AlertMessage("删除" + strText + "成功！");
            }
            else
            {
                AlertMessage("删除" + strText + "失败！");
            }
            BindType();
        }
    }
}