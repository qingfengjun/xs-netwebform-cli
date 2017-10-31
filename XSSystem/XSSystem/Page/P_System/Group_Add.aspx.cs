using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xs_System.Logic;
using xsFramework.Web.WebPage;

namespace xs_System.Page.P_System
{
    public partial class Group_Add : AuthWebPage
    {
        groupLogic pageLogic = new groupLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DirModel dml = new DirModel();
            //新增页面
            string strid = "G" + DateTime.Now.ToString("yyyyMMddHHssmmm");
            dml.Add("@group_id", strid);
            dml.Add("@group_name", txtgroupName.Text.Trim());
            if (!pageLogic.ExistGroup(dml))
            {
                dml.Add("@group_remark", txtgroupRemark.Text.Trim());
                if (pageLogic.AddGroup(dml))
                {
                    AlertMessageAndGoTo("新增群组成功！", "/Page/P_System/Group.aspx");
                }
                else
                {
                    AlertMessageAndGoTo("新增群组失败！", "/Page/P_System/Group.aspx");
                }
            }
            else
            {
                AlertMessage("群组已经存在！");
            }
        }
    }
}