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
    public partial class News_Edit : AuthWebPage
    {
        newsLogic pageLogic = new newsLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlNewType.DataSource = pageLogic.QueryNewType();
                ddlNewType.DataTextField = "new_type_name";
                ddlNewType.DataValueField = "new_type_id";
                ddlNewType.DataBind();

                if (Request["type"] != null && Request["id"] != null)
                {
                    btnSave.Visible = false;
                    hidID.Value = Request["id"].ToString();
                    DataTable dt = pageLogic.QueryNewByID(hidID.Value);
                    if (dt.Rows.Count != 0)
                    {
                        txtTitle.Text = dt.Rows[0]["new_title"].ToString();
                        txtContent.Text = dt.Rows[0]["new_content"].ToString();
                        try
                        {
                            ddlNewType.SelectedValue = dt.Rows[0]["new_type_id"].ToString();
                            ddlSort.SelectedValue = dt.Rows[0]["new_sort"].ToString();
                        }
                        catch(Exception ex)
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
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtContent.Text.Length == 0)
            {
                AlertMessage("内容不能为空.");
                return;
            }
            DirModel dml = new DirModel();
            dml.Add("@new_title", txtTitle.Text.Trim());
            dml.Add("@new_content", txtContent.Text);
            dml.Add("@new_type_id", ddlNewType.SelectedValue);
            dml.Add("@new_sort", ddlSort.SelectedValue);
            dml.Add("@create_user", LoginUser.LoginUser);
            if (pageLogic.InsertNew(dml))
            {
                AlertMessageAndGoTo("新增成功.", "/Page/P_News/News_Query.aspx");
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (txtContent.Text.Length == 0)
            {
                AlertMessage("内容不能为空.");
                return;
            }
            DirModel dml = new DirModel();
            dml.Add("@new_id", hidID.Value);
            dml.Add("@new_title", txtTitle.Text.Trim());
            dml.Add("@new_content", txtContent.Text);
            dml.Add("@new_type_id", ddlNewType.SelectedValue);
            dml.Add("@new_sort", ddlSort.SelectedValue);
            dml.Add("@update_user", LoginUser.LoginUser);
            if (pageLogic.UpdateNew(dml))
            {
                AlertMessageAndGoTo("修改成功.", "/Page/P_News/News_Query.aspx");
            }
        }
    }
}