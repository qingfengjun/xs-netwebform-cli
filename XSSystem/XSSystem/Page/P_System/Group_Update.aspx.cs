using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xs_System.Logic;
using xsFramework.Web.WebPage;


namespace xs_System.Page.P_System
{
    public partial class Group_Update : AuthWebPage
    {
        groupLogic pageLogic = new groupLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["id"] != null)
                {
                    string strGroupID = Request["id"].ToString();
                    DirModel dml = new DirModel();
                    dml.Add("@group_id", strGroupID);
                    DataTable dt = pageLogic.QueryGroupByID(dml);
                    if (dt.Rows.Count > 0)
                    {
                        lblGroup.Text = strGroupID + "(" + dt.Rows[0]["group_name"].ToString() + ")";
                        txtgroupName.Text = dt.Rows[0]["group_name"].ToString();
                        txtgroupRemark.Text = dt.Rows[0]["group_remark"].ToString();
                        hidsaveid.Value = strGroupID;
                    }
                    else
                    {
                        AlertMessageAndGoTo("页面错误", "/Page/P_System/Group.aspx");
                    }
                }
                else
                {
                    AlertMessageAndGoTo("页面错误", "/Page/P_System/Group.aspx");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DirModel dml = new DirModel();
            string strid = hidsaveid.Value.Trim();
            dml.Add("@group_id", strid);
            dml.Add("@group_name", txtgroupName.Text.Trim());
            if (!pageLogic.ExistGroup(dml))
            {
                dml.Add("@group_remark", txtgroupRemark.Text.Trim());
                if (pageLogic.UpdateGroup(dml))
                {
                    AlertMessageAndGoTo("更新群组成功！", "/Page/P_System/Group.aspx");

                }
                else
                {
                    AlertMessageAndGoTo("更新群组失败！", "/Page/P_System/Group.aspx");
                }
            }
            else
            {
                AlertMessage("有相同名称的群组存在!");
            }
        }
    }
}