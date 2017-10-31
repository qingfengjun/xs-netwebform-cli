using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xs_System.Logic;
using xsFramework.Web.WebPage;
namespace xs_System.Page.P_Product
{
    public partial class ProductType : AuthWebPage
    {
        ProductLogic pagelogic = new ProductLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindType();
            }
        }

        private void BindType()
        {
            DataTable dtType = pagelogic.QueryProductType();
            ddlType.DataSource = dtType;
            ddlType.DataTextField = "product_type_name";
            ddlType.DataValueField = "product_type_id";
            ddlType.DataBind();
            ddlType.Items.Insert(0, new ListItem("新增产品类别", ""));
            btnDelete.Visible = false;
            txtRemark.Text = "";
            txtName.Text = "";
            btnSave.Text = "新增产品类别";
            Session["dtType"] = dtType;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DirModel dml = new DirModel();

            dml.Add("@producttype_name", txtName.Text);
            dml.Add("@producttype_remark", txtRemark.Text);
            if (string.IsNullOrEmpty(ddlType.SelectedValue))
            {
                //新增
                dml.Add("@producttype_id", "PT" + DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                if (pagelogic.InsertProductType(dml))
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
                dml.Add("@producttype_id", ddlType.SelectedValue);
                if (pagelogic.UpdateProductType(dml))
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
            dml.Add("@producttype_id", ddlType.SelectedValue);
            if (pagelogic.DeleteProductType(dml))
            {
                AlertMessage("删除" + strText + "成功！");
            }
            else
            {
                AlertMessage("删除" + strText + "失败！");
            }
            BindType();
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlType.SelectedValue))
            {
                txtRemark.Text = "";
                txtName.Text = "";
                btnDelete.Visible = false;
                btnSave.Text = "新增产品类别";
            }
            else
            {
                if (Session["dtType"] != null)
                {
                    DataTable dtType = Session["dtType"] as DataTable;
                    DataRow[] drs = dtType.Select("product_type_id='" + ddlType.SelectedValue + "'");
                    if (drs.Length > 0)
                    {
                        txtRemark.Text = drs[0]["product_type_remark"].ToString();
                        txtName.Text = drs[0]["product_type_name"].ToString();
                        btnSave.Text = "更新产品类别";
                        btnDelete.Visible = true;

                    }
                }
            }
        }
    }
}