# XSSystem
asp.net webform 打造私人后台管理系统（附源码）
不少人让我做公司的网站，要求不多，但是需要有一个后台系统，所以就有了开发的动力。也想做个系统自己学习一下，反正平时也不知道干啥。

　本系统采用的是asp.net webform+ado.net，也许现在用的很少了，但是的确是简单粗暴，还是很方便的。这个后台系统是我一个人制作，从布局，写类库到数据库设计，总算有一个算是我私人的系统了。虽然比较简单，很多地方设计不到位，但是既然开始了，就不能中断了，我还是坚持把这个系统做完了。后面我自己开发准备使用asp.net mvc+EF。webform只是一段经历，我觉得这段经历很重要，从易到难，一步一个脚印。

　　去年就一直在工作，一直在进行一些学习和准备，中间也进行过一些大改动，如改为ajax+ashx,改权限设计等。

系统UI

感觉UI要做的好看很麻烦，反正整的觉得不恶心就可以了，下面是登录页面



主要页面



 工程介绍

 

1:xsFramework.Function  里面有生成验证码等一些辅助方法，目前方法比较少

2:xsFramework.SqlServer 数据库操作类，具体介绍可以看刚整了一个数据库操作类，但是可以用吗

　　数据库操作例子，还算是比较简单的，但是sql这样是不是很那个...

复制代码
        /// <summary>
        /// 新增招聘
        /// </summary>
        /// <returns></returns>
        public bool AddHire(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"insert into [dbo].[xs_hire]([hire_id],[hire_name],[hire_count],[hire_place],[hire_remark])
                            values (@hire_id ,@hire_name,@hire_count,@hire_place,@hire_remark)";
            SqlHelper.Execute(sqlpara);
            return true;
        }
复制代码
 

3:xsFramework.UserControl 控件库，目前只有一个分页控件和其辅助方法，具体实现可以看asp.net 分页-自己写分页控件

前台直接拖过去就可以使用，后台用控件库里面的类进行分页

<cc1:xsPageControl ID="xsPage" runat="server"OnPageChanged="xsPage_PageChanged">
            </cc1:xsPageControl>
复制代码
        protected void xsPage_PageChanged(object sender, xsFramework.UserControl.Pager.PageChangedEventArgs e)
        {
            PagerParameter pagepara = new PagerParameter();
            pagepara.DbConn = GlabalString.DBString;
            pagepara.XsPager = xsPage;
            pagepara.Sql = pageLogic.QueryNews(ddlNewType.SelectedValue,txtNewName.Text.Trim());
            pagepara.OrderBy = "new_id";

            DataTable dt = xsPageHelper.BindPager(pagepara, e);
            Nodata.Visible = false;
            if (dt.Rows.Count == 0) Nodata.Visible = true;

            rptNews.DataSource = dt;
            rptNews.DataBind();
        }
复制代码
复制代码
        /// <summary>
        /// 根据页码查询新闻
        /// </summary>
        /// <returns></returns>
        public string QueryNews(string strType,string strName)
        {
            string sql = @"select new_id,new_title,
                            dbo.f_ConvertDate(a.create_time) create_time, b.user_name from xs_new a
                            left join xs_users b on b.user_no=a.create_user where 1=1 ";
            if (!string.IsNullOrEmpty(strType)) sql += " and a.new_type_id='" + strType + "'";
            if (!string.IsNullOrEmpty(strName)) sql += " and a.new_title like '%" + strName + "%'";
            return sql;
        }
复制代码
 4：xsFramework.Web 页面辅助库，继承自page,进行页面的权限设定

系统权限

新增群组，群组设定功能，用户设定群组，取得用户某个功能的权限，可参考系统权限之简单设计

1：查询群组，index.aspx页面进入时根据登录者查询出需要的群组，进行菜单显示

复制代码
if(select MAX(group_id) from xs_group_user where user_no=@user_no)='G001'
begin
select f.function_id,f.function_brother_id,f.function_parent_id,f.function_level,f.function_name,f.function_url,f.function_sort, f.function_action group_action 
from xs_function f where f.function_inmenu=1
end
else
begin
select f.function_id,f.function_brother_id,f.function_parent_id,f.function_level,f.function_name,f.function_url,f.function_sort,gf.group_action from 
[xs_group_user] gu
inner join [xs_group_function] gf on gf.group_id=gu.group_id
inner join xs_function f on f.function_id=gf.function_id and f.function_inmenu=1
where gu.user_no=@user_no
end

复制代码
2：页面继承xsFramework.Web 中的AuthWebPage类，自动去判断权限和访问设定。

复制代码
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
复制代码


3：如果一个页面有新增权限，代码为02，那么设置需要的html元素actionid为02，权限类会自动对其进行显示和隐藏

  <asp:Button ID="btnSave" runat="server" Text="新增" CssClass="button" 
            ValidationGroup="Save" onclick="btnSave_Click" actionid="02" />
 

 结尾+源代码(Download)

本想写几篇博客进行介绍，但是感觉有点浪费时间，所以简单的说了一下，我觉得有源代码这些都不是问题了。请珍惜我的劳动成果，希望看到大家的批评和建议。本系统对初学者可能帮助比较大，高手们可以直接跳过了，应为我觉得我就是菜鸟...

 DB是sql server 导出的，自己进行建立，publish可以直接部署到IIS，source是源代码用的是vs2012，vs2010要运行可以直接新建一个工程拷过去。最后别忘了改变DB链接。
