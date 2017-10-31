using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using xsFramework.Web.WebPage;
using xsFramework.SqlServer;

namespace xs_System.Logic
{
    public class MessageLogic
    {
        /// <summary>
        /// 更新招聘
        /// </summary>
        /// <returns></returns>
        public bool UpdateMain(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"update [xs_main] set [main_content]=@main_content,updateuser=@updateuser
                            where [main_id]=@main_id ";
            SqlHelper.Execute(sqlpara);
            return true;
        }
        /// <summary>
        /// 查询类别和id
        /// </summary>
        /// <returns></returns>
        public DataTable QueryMainName()
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"select distinct [main_id], [main_name] from [xs_main]";
            return SqlHelper.GetDataTable(sqlpara);

        }
        /// <summary>
        /// 根据id查询内容
        /// </summary>
        /// <returns></returns>
        public string QueryMainContent(string strID)
        {
            string strReturn = "";
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter("@main_id", strID);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"select main_content from [xs_main] where [main_id]=@main_id";
            DataTable dt = SqlHelper.GetDataTable(sqlpara);
            if (dt.Rows.Count > 0)
            {
                strReturn = dt.Rows[0]["main_content"].ToString();
            }
            return strReturn;

        }
    }
}