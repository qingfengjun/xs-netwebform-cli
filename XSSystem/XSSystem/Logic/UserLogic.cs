using System.Data;
using xsFramework.SqlServer;
using xsFramework.Web.WebPage;

namespace xs_System.Logic
{
    public class UserLogic
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public string QueryUser(string strGroup)
        {
            string sql = @"select u.user_no,u.[user_name],u.user_password,g.group_name,g.group_id from [xs_users] u
                    inner join [xs_group_user] gu on  gu.user_no=u.user_no and  gu.group_id<>'G001'
                    inner join [dbo].[xs_group] g on gu.group_id=g.group_id";
            if (!string.IsNullOrEmpty(strGroup))
                sql += " and g.group_id='" + strGroup + "'";
            return sql;
        }
        /// <summary>
        /// 查询用户可以选择的群组
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public DataTable QueryUserGroup()
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"select [group_id],[group_name] from [xs_group]  where group_id<>'G001'";
            return SqlHelper.GetDataTable(sqlpara);
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public bool AddUser(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"delete from [dbo].[xs_users] where [user_no]=@userid
                            insert into [xs_users]([user_no],[user_name],[user_password]) values(@userid,@userName,@userpassword)
                            delete from [dbo].[xs_group_user] where [user_no]=@userid
                            insert into [xs_group_user]([group_id],[user_no]) values(@usergroup,@userid)";
            SqlHelper.Execute(sqlpara);
            return true;

        }
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public bool UpdateUser(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"update [xs_users] set [user_name]=@userName where [user_no]=@userid
                            update [xs_group_user] set [group_id]=@usergroup where [user_no]=@userid";
            SqlHelper.Execute(sqlpara);
            return true;
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public bool DeleteUser(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"delete from [xs_users]where [user_no]=@userid
                            delete from [xs_group_user] where  [user_no]=@userid";
            SqlHelper.Execute(sqlpara);
            return true;
        }
        /// <summary>
        /// 判断用户存在
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public bool ExistUser(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"select * from [dbo].[xs_users] where [user_no]=@userid";
            return SqlHelper.Exist(sqlpara);
        }
        /// <summary>
        /// 判断用户存在
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public bool ChangeUserPassword(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"update dbo.xs_users
                            set user_password=@user_password
                            where user_no=@user_no";
            SqlHelper.Execute(sqlpara);
            return true;
        }
    }
}