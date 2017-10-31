using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using xsFramework.SqlServer;
using xsFramework.Web.WebPage;
namespace xs_System.Logic
{
    public class LeaveLogic 
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public string QueryLeave()
        {
            string sql = @"select [leave_id]
                          ,[leave_Content]
                          ,[leave_time]
                          ,(case when isnull([leave_contact],'')='' then N'无联系方式' else leave_contact end)leave_contact
                          ,(case when isnull(leave_user,'')='' then N'匿名' else leave_user end)leave_user  from [dbo].[xs_leave]";
            return sql;
        }
        /// <summary>
        /// 招聘留言
        /// </summary>
        /// <returns></returns>
        public bool DeleteLeave(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"delete from [dbo].[xs_leave] where leave_id=@leave_id";
            SqlHelper.Execute(sqlpara);
            return true;
        }
    }
}