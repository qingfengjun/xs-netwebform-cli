using System.Data;
using xsFramework.Web.WebPage;
using xsFramework.SqlServer;
namespace xs_System.Logic
{
    public class MenuLogic
    {
        public DataTable QueryMenu(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"if(select MAX(group_id) from xs_group_user where user_no=@user_no)='G001'
                            begin
                            select f.function_id,f.function_brother_id,f.function_parent_id,f.function_level,f.function_name,f.function_url,f.function_sort, f.function_action  group_action  
                            from xs_function f  where f.function_inmenu=1
                            end
                            else
                            begin
                            select f.function_id,f.function_brother_id,f.function_parent_id,f.function_level,f.function_name,f.function_url,f.function_sort,gf.group_action from 
                            [xs_group_user] gu
                            inner join [xs_group_function] gf on gf.group_id=gu.group_id
                            inner join xs_function f on f.function_id=gf.function_id  and f.function_inmenu=1
                            where gu.user_no=@user_no
                            end";
            return SqlHelper.GetDataTable(sqlpara);
        }
    }
}