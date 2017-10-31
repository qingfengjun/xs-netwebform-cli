using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xs_System.Logic;

using System.Text;
using xsFramework.Web.WebPage;
namespace xs_System.Page.P_System
{
    public partial class Group_Function :AuthWebPage
    {
        groupLogic pageLogic = new groupLogic();
        DataTable dtAction = new DataTable();//所有的群组列表
        DataTable dtHasAction = new DataTable();//当前群组所拥有的群组
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
                        lblName.Text = dt.Rows[0]["group_name"].ToString();
                        lblRemark.Text = dt.Rows[0]["group_remark"].ToString();
                        hidGroupID.Value = strGroupID;
                        BindGrid();
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

        private void BindGrid()
        {
            DirModel dml = new DirModel();
            dml.Add("@group_id", hidGroupID.Value);
            DataSet dsMain = pageLogic.QueryGroupFunction(dml);
            if (dsMain.Tables.Count == 3)
            {
                dtAction = dsMain.Tables[1];
                dtHasAction = dsMain.Tables[2];
                gvGroupFunction.DataSource = dsMain.Tables[0];
                gvGroupFunction.DataBind();
            }



        }

        protected void gvGroupFunction_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBoxList cblAction = e.Row.Cells[1].FindControl("cblAction") as CheckBoxList;
                HiddenField hidTThisAction = e.Row.Cells[1].FindControl("hidThisAction") as HiddenField;
                HiddenField hidFunctionID = e.Row.Cells[1].FindControl("hidFunctionID") as HiddenField;
                string strAction = hidTThisAction.Value;
                foreach (DataRow drAction in dtAction.Rows)
                {

                    if (strAction.Contains(drAction["action_id"].ToString()))
                    {
                        ListItem list = new ListItem(drAction["action_name"].ToString(), drAction["action_id"].ToString());
                        if (GroupFunction(hidFunctionID.Value).Contains(drAction["action_id"].ToString()))
                        {
                            list.Selected = true;
                        }
                        cblAction.Items.Add(list);
                    }
                }
            }
        }

        /// <summary>
        /// 获取当前群组当前功能的权限
        /// </summary>
        /// <param name="functionid"></param>
        /// <returns></returns>
        private string GroupFunction(string functionid)
        {
            string strGroupAction = "";
            DataRow[] drThisActions = dtHasAction.Select("function_id='" + functionid + "'");
            if (drThisActions.Length > 0)
            {
                strGroupAction = drThisActions[0]["group_action"].ToString();
            }
            return strGroupAction;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtGroupFunction = new DataTable();
            dtGroupFunction.Columns.Add("group_id");
            dtGroupFunction.Columns.Add("function_id");
            dtGroupFunction.Columns.Add("group_action");
            List<string> listParentIDs = new List<string>();
            string strGroupID = hidGroupID.Value;//当前群组的ID
            foreach (GridViewRow gvr in gvGroupFunction.Rows)
            {
                HiddenField hidFunctionID = gvr.Cells[1].FindControl("hidFunctionID") as HiddenField;
                HiddenField hidParentId = gvr.Cells[1].FindControl("hidParentId") as HiddenField;
                CheckBoxList cblAction = gvr.Cells[1].FindControl("cblAction") as CheckBoxList;
                StringBuilder sbAction = new StringBuilder();

                foreach (ListItem list in cblAction.Items)
                {
                    if (list.Selected)
                    {
                        sbAction.Append(list.Value + ",");
                    }
                }
                if (sbAction.Length > 0)
                {
                    string strAction = sbAction.ToString().Substring(0, sbAction.Length - 1);
                    DataRow drGroupFunction = dtGroupFunction.NewRow();
                    drGroupFunction["group_id"] = strGroupID;
                    drGroupFunction["function_id"] = hidFunctionID.Value;
                    drGroupFunction["group_action"] = strAction;
                    dtGroupFunction.Rows.Add(drGroupFunction);
                    listParentIDs.Add(hidParentId.Value);

                }
            }
            listParentIDs = listParentIDs.Distinct().ToList();
            foreach (string strParentID in listParentIDs)
            {
                DataRow drGroupFunction = dtGroupFunction.NewRow();
                drGroupFunction["group_id"] = strGroupID;
                drGroupFunction["function_id"] = strParentID;
                dtGroupFunction.Rows.Add(drGroupFunction);
            }
            if (pageLogic.InsetDataTable(dtGroupFunction, strGroupID))
            {
                AlertMessageAndGoTo("修改群组权限成功！", "/Page/P_System/Group.aspx");
            }
            else
            {
                AlertMessage("修改群组权限失败！");
            }
        }
    }
}