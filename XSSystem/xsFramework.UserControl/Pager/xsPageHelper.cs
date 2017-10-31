using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using xsFramework.SqlServer;

namespace xsFramework.UserControl.Pager
{
    public class xsPageHelper
    {


        public static DataTable BindPager(PagerParameter pagePara,PageChangedEventArgs e)
        {
            #region datasafe
            if (pagePara.OrderBy.Length == 0)
            {
                throw new Exception(" must set groupby!");
            }
            
            #endregion

            //data sum count
            string strCount = "select Count(*) from (" + pagePara.Sql + ")T";
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.SQL = strCount;
            sqlpara.SqlConnectString = pagePara.DbConn;
            DataTable dtCount = SqlHelper.GetDataTable(sqlpara);
            int DataCount = Convert.ToInt32(dtCount.Rows[0][0]);
            pagePara.XsPager.TotalCount = DataCount;//set total count
            if (DataCount <= 0) return new DataTable();

            
            int pageSize = pagePara.XsPager.PageSize;
            
            pageSize = pageSize <= 0 ? 10 : pageSize;
            

            StringBuilder sbPageSql = new StringBuilder();
            sbPageSql.Append("SELECT * FROM(");
            sbPageSql.Append("SELECT *,ROW_NUMBER() OVER(ORDER BY " + pagePara.OrderBy + ") PID FROM (");
            sbPageSql.Append(pagePara.Sql);
            sbPageSql.Append(")Tsql )T WHERE PID between ");
            sbPageSql.Append(((e.CurrentPage - 1) * pageSize+1).ToString());
            sbPageSql.Append(" AND ");
            sbPageSql.Append((e.CurrentPage - 1) * pageSize + pageSize);

            sqlpara.SQL = sbPageSql.ToString();
            return SqlHelper.GetDataTable(sqlpara);
        }
    }
}
