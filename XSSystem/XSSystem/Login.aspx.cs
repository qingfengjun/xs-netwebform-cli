using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using xs_System.logic;
using xsFramework.SqlServer;
using xsFramework.Web.WebPage;
using xsFramework.Web.Login;

namespace xs_System
{
    public partial class Login : WebPage
    {
        LoginLogic pagelogic = new LoginLogic();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetCookie();
            }
        }

        //判断cookie
        private void SetCookie()
        {
            if (Request.Cookies["xsCookie"] != null)
            {
                DirModel dml = new DirModel();
                dml.Add("@user_no", Request.Cookies["xsCookie"]["xs_UserNo"].ToString());
                dml.Add("@user_password", Request.Cookies["xsCookie"]["xs_UserPassword"].ToString());
                DataTable dt = pagelogic.QueryUser(dml);
                if (dt.Rows.Count == 0)
                {
                    lblMsg.Text = "账号或密码错误.";
                    return;
                }
                else
                {
                    SetLoginSession(dt, dml);
                }
                Response.Redirect("index.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string strCheckCode = Session["CheckCode"].ToString().ToLower();
            if (strCheckCode.Equals(txtAuth.Text.ToLower()))
            {
                DirModel dml = new DirModel();
                dml.Add("@user_no", txtAdmin.Value);
                dml.Add("@user_password", txtPassword.Value);
                DataTable dt = pagelogic.QueryUser(dml);
                if (dt.Rows.Count == 0)
                {
                    lblMsg.Text = "账号或密码错误.";
                }
                else
                {
                    SetLoginSession(dt, dml);
                    // 判断记住密码
                    if (chkRemember.Checked)
                    {
                        HttpCookie cookie = new HttpCookie("xsCookie");
                        cookie.Values.Add("xs_UserNo", txtAdmin.Value.Trim());
                        cookie.Values.Add("xs_UserPassword", txtPassword.Value.Trim());
                        //设置
                        DateTime dts = DateTime.Now;
                        TimeSpan ts = new TimeSpan();
                        if ("1".Equals(ddlTime.SelectedValue))
                        {
                            ts = new TimeSpan(10, 0, 0, 0);//过期时间为10天
                        }
                        else if ("2".Equals(ddlTime.SelectedValue))
                        {
                            ts = new TimeSpan(30, 0, 0, 0);//过期时间为一个月
                        }
                        else if ("3".Equals(ddlTime.SelectedValue))
                        {
                            ts = new TimeSpan(365, 0, 0, 0);//过期时间为一年
                        }

                        cookie.Expires = dts.Add(ts);//设置过期时间
                        Response.AppendCookie(cookie);

                    }
                    Response.Redirect("index.aspx");
                }
            }
            else
            {
                lblMsg.Text = "验证码错误.";
            }
        }

        /// <summary>
        /// 设置页面的session
        /// </summary>
        /// <param name="dt">用户信息</param>
        /// <param name="dml">查询条件</param>
        private void SetLoginSession(DataTable dt,DirModel dml)
        {
            DataTable dtFunction = pagelogic.QueryMenu(dml);
            LoginModel model = new LoginModel();
            model.LoginUser = dt.Rows[0]["user_no"].ToString();
            model.LoginUserName = dt.Rows[0]["user_name"].ToString();
            model.LoginUserGroup = dt.Rows[0]["group_id"].ToString();
            model.LoginUserGroupName = dt.Rows[0]["group_name"].ToString();
            model.LoginUserPassword = dt.Rows[0]["user_password"].ToString();
            foreach (DataRow drfunction in dtFunction.Rows)
            {
                model.AddFunction(drfunction["function_url"].ToString(), drfunction["group_action"].ToString());
            }
            Session["LoginModel"] = model;
        }
    }
}