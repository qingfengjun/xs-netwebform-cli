using System;
using System.Data;
using System.Text;
using System.Web;
using xsFramework.Web.WebPage;
using xs_System.Logic;
namespace xs_System
{
    public partial class index : AuthWebPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFunction();
                lblLoginUser.Text = LoginUser.LoginUser + "(" + LoginUser.LoginUserName + ")";
            }
        }

        /// <summary>
        /// 根据user绑定菜单
        /// </summary>
        private void BindFunction()
        {
            MenuLogic logic = new MenuLogic();
            DirModel dml = new DirModel();
            dml.Add("@user_no", LoginUser.LoginUser);
            DataTable dtMenu = logic.QueryMenu(dml);
            StringBuilder strMenu = new StringBuilder();
            DataRow[] drLevelones = dtMenu.Select("function_level=1", "function_sort asc");
            foreach (DataRow drLevelone in drLevelones)
            {
                strMenu.Append(@"<li> <h4>" + drLevelone["function_name"].ToString() + @"</h4>");
                DataRow[] drLeveltwos = dtMenu.Select("function_level=2 and function_parent_id='" + drLevelone["function_id"].ToString() + "'", "function_sort asc");
                if (drLeveltwos.Length > 0)
                {
                    strMenu.Append(@"<div class=""list-item none"">");
                    foreach (DataRow drLeveltwo in drLeveltwos)
                    {
                        strMenu.Append(@"  <p> <a href="""+drLeveltwo["function_url"].ToString()+@""" onclick="" return setUrl('" + drLeveltwo["function_url"].ToString() + @"')"">" + drLeveltwo["function_name"].ToString() + @"</a></p>");
                    }
                    strMenu.Append(@" </div>");
                }
                strMenu.Append(@" </li>");
            }

            J_navlist.InnerHtml = strMenu.ToString();
        }

        protected void btnLoginOut_Click(object sender, EventArgs e)
        {
            //清除session
            if (Session["LoginModel"] != null)
            {
                Session["LoginModel"] = null;
            }
            //清除cookie
            HttpCookie cok = Request.Cookies["xsCookie"];
            if (cok != null)
            {
                TimeSpan ts = new TimeSpan(-1, 0, 0, 0);
                cok.Expires = DateTime.Now.Add(ts);//删除整个Cookie，只要把过期时间设置为现在
                Response.AppendCookie(cok);
            }
            //页面跳转
            Response.Redirect("Login.aspx");
        }
    }
}