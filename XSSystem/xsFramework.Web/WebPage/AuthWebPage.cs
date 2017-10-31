//****************************************************************************************
//author xiaoshuai
//blog：http://www.cnblogs.com/xiaoshuai1992
//create: 2014/7/4
//function： page access
//*****************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xsFramework.Web.Login;

namespace xsFramework.Web.WebPage
{
    public class AuthWebPage : WebPage
    {
        private string _actions = "";

        #region 页面权限的设定
        protected override void OnLoad(EventArgs e)
        {
            //判断session是否存在
            if (LoginUser == null)
            {
                NotLogin();
                return;// 不受postback下面的影响
            }
            else
            {
                string thisUrl = Request.RawUrl.Trim().Split('?')[0].ToLower();

                if ("/index.aspx".Equals(thisUrl))
                {
                    _actions = "01";//如果有登录首页默认有查询权限
                }
                var functions = LoginUser.Functions.Where(f => f.FunctionUrl.ToLower().Equals(thisUrl));

                if (functions.Count() != 0)
                {
                    _actions = functions.First().FunctionActions;
                }
                if (_actions.Length == 0)
                {
                    NotAccess();//not access
                    return;
                }
                else
                {
                    SetAction();// access
                }
            }
            base.OnLoad(e);
        }

        /// <summary>
        /// 无权限访问页面显示
        /// </summary>
        private void NotAccess()
        {
            this.Visible = false;
            Response.Write(@"<html><head>
                                <title>无权限访问</title>
                            </head>
                            <body>
                                <div style=""margin: auto; text-align: center;"">
                                    <h3>
                                        对不起，您无权访问此页面，请与系统管理联系.</h3>
                                    <a href=""/Page/P_Public/Main.aspx"">回到主页</a>
                                </div>
                            </body>
                            </html>");
        }

        /// <summary>
        /// session 丢失时页面时页面的显示
        /// </summary>
        private void NotLogin()
        {
            this.Visible = false;
            Response.Write(@"<html><head>
                                <title>登录超时</title>
                                <script type=""text/javascript"">
                                    function Goto() {
                                        if (window != top) {
                                            top.location.href = '/Login.aspx';
                                        }
                                        else {
                                            window.location.href = '/Login.aspx';
                                        }
                                        return false;
                                    }
                                </script>
                            </head>
                            <body>
                                <div style=""margin: auto; text-align: center;"">
                                    <h3>
                                        操作超时，请重新登录.</h3>
                                    <a href=""/Login.aspx"" onclick=""return Goto()"">重新登录</a>
                                </div>
                            </body>
                            </html>");
        }

        /// <summary>
        /// 为页面上元素设置权限,需要页面上引用jquery
        /// </summary>
        private void SetAction()
        {
            string script = @"$(document).ready(function () {
                                $(""[actionid]"").hide();
                                    var strActionIDs = """ + _actions + @""".split(',');
                                    for (var i = 0; i < strActionIDs.length; i++) {
                                        if (strActionIDs[i].length > 0) {
                                            $(""[actionid*='"" + strActionIDs[i] + ""']"").show();
                                        }
                                    }
                                });";
            JavaScript(script);
        }
        #endregion


    }
}
