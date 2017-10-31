using System.Data;
using xsFramework.SqlServer;
using xsFramework.Web.WebPage;

namespace xs_System.logic
{
    public class LoginLogic
    {
        /// <summary>
        /// 是否匹配账号密码
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public DataTable QueryUser(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"select u.user_no,u.user_name,u.[user_password],gu.group_id,g.group_name from xs_users u
                            left join dbo.xs_group_user gu  on gu.user_no=u.user_no
                            left join dbo.xs_group g on g.group_id=gu.group_id where u.user_no=@user_no and u.user_password=@user_password";
            return SqlHelper.GetDataTable(sqlpara);

        }

        /// <summary>
        /// 登入后页面的权限
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public DataTable QueryMenu(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"if(select MAX(group_id) from xs_group_user where user_no=@user_no)='G001'
                                begin
                                select f.function_url,f.function_action group_action from xs_function f
                                where isnull(function_url,'')<>'' and isnull(function_action,'')<>''
                                end
                                else
                                begin
                                select distinct f.function_url,gf.group_action from xs_group_user gu
                                join xs_group_function gf on gu.group_id=gf.group_id
                                join xs_function f on f.function_id=gf.function_id
                                where gu.user_no=@user_no  and isnull(gf.group_action,'')<>''
                                end ";
            return SqlHelper.GetDataTable(sqlpara);
        }

    }
}