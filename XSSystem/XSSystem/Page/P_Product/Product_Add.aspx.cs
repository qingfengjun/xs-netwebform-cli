using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xs_System.Logic;
using xsFramework.Function.Thumbnail;
using xsFramework.Web.WebPage;
using System.Data;

namespace xs_System.Page.P_Product
{
    public partial class Product_Add : AuthWebPage
    {
        ProductLogic pageLogic = new ProductLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();
            }
        }
        private void InitData()
        {

            ddlType.DataSource = pageLogic.QueryProductType();
            ddlType.DataTextField = "product_type_name";
            ddlType.DataValueField = "product_type_id";
            ddlType.DataBind();
            if (Request["type"] != null && Request["id"] != null)
            {
                btnSave.Visible = false;
                hidID.Value = Request["id"].ToString();
                DataTable dt = pageLogic.QueryProductByID(hidID.Value);
                if (dt.Rows.Count != 0)
                {
                    txtTitle.Text = dt.Rows[0]["product_title"].ToString();
                    txtContent.Text = dt.Rows[0]["product_content"].ToString();
                    txtRemark.Text = dt.Rows[0]["product_remark"].ToString();
                    txtPic.Text = dt.Rows[0]["product_imgurl"].ToString();
                    try
                    {
                        ddlType.SelectedValue = dt.Rows[0]["product_type_id"].ToString();

                    }
                    catch (Exception ex)
                    {
                        AlertMessage(ex.Message);
                    }
                }
                else
                {
                    AlertMessage("数据已被异动.");
                }
            }
            else
            {
                btnModify.Visible = false;
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtContent.Text.Trim().Length == 0)
            {
                AlertMessage("产品内容不能为空");
            }
            if (string.IsNullOrEmpty(ddlType.SelectedValue))
            {
                AlertMessage("请先添加产品类别，再来添加产品.");
                return;
            }
            DirModel dml = new DirModel();
            dml.Add("@product_title", txtTitle.Text.Trim());
            dml.Add("@product_remark", txtRemark.Text.Trim());
            dml.Add("@product_content", txtContent.Text.Trim());
            dml.Add("@product_imgurl", txtPic.Text.Trim());
            dml.Add("@product_type_id", ddlType.SelectedValue);
            dml.Add("@product_create_user", LoginUser.LoginUser);
            if (pageLogic.InsertProduct(dml))
            {
                AlertMessageAndGoTo("新增成功", "product.aspx");

            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            DirModel dml = new DirModel();
            dml.Add("@product_title", txtTitle.Text.Trim());
            dml.Add("@product_remark", txtRemark.Text.Trim());
            dml.Add("@product_content", txtContent.Text.Trim());
            dml.Add("@product_type_id", ddlType.SelectedValue);
            dml.Add("@product_imgurl", txtPic.Text.Trim());
            dml.Add("@product_update_user", LoginUser.LoginUser);
            dml.Add("@product_id", hidID.Value);
            if (pageLogic.UpdateProduct(dml))
            {
                AlertMessageAndGoTo("修改成功", "product.aspx");

            }
        }

    }
}