using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using xsFramework.Web.WebPage;
using xsFramework.SqlServer;

namespace xs_System.Logic
{
    public class newsLogic
    {
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

        public DataTable QueryNewType()
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"select * from xs_new_type";
            return SqlHelper.GetDataTable(sqlpara);
        }

        public DataTable QueryNewByID(string strID)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.AddSqlParameter("@new_id", strID);
            sqlpara.SQL = @"select new_title,new_content,create_user,create_time,new_type_id,new_sort from dbo.xs_new
                                where new_id=@new_id";
            return SqlHelper.GetDataTable(sqlpara);
        }

        /// <summary>
        /// 新增动态
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public bool InsertNew(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"insert into dbo.xs_new([new_title]
                          ,[new_content]
                          ,[create_time]
                          ,[create_user]
                          ,[update_user]
                          ,[update_time]
                          ,[new_type_id]
                          ,[new_sort])
                          values
                          (@new_title
                          ,@new_content
                          ,GETDATE()
                          ,@create_user
                          ,@create_user
                          ,getdate()
                          ,@new_type_id
                          ,@new_sort)";
            SqlHelper.Execute(sqlpara);
            return true;
        }

        /// <summary>
        /// 维护动态
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public bool UpdateNew(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"update dbo.xs_new
                            set new_title=@new_title
                            ,new_content=@new_content
                            ,update_user=@update_user
                            ,update_time=GETDATE()
                            ,new_type_id=@new_type_id
                            ,new_sort=@new_sort
                            where new_id=@new_id";
            SqlHelper.Execute(sqlpara);
            return true;
        }
        /// <summary>
        /// 删除动态
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public bool DeleteNew(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"
                            delete from dbo.xs_new where [new_id]=@new_id";
            SqlHelper.Execute(sqlpara);
            return true;
        }
        /// <summary>
        /// 新增动态类别
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public bool InsertNewType(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"insert into dbo.xs_new_type([new_type_id],[new_type_name],[new_type_remark])
                                values(@new_type_id,@new_type_name,@new_type_remark)";
            SqlHelper.Execute(sqlpara);
            return true;
        }

        /// <summary>
        /// 更新动态类别
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public bool UpdateNewType(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"update xs_new_type set [new_type_name]=@new_type_name,[new_type_remark]=@new_type_remark
                            where [new_type_id]=@new_type_id";
            SqlHelper.Execute(sqlpara);
            return true;
        }
        /// <summary>
        /// 删除动态类别
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public bool DeleteNewType(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"delete from  dbo.xs_new_type  where [new_type_id]=@new_type_id
                            delete from dbo.xs_new where [new_type_id]=@new_type_id";
            SqlHelper.Execute(sqlpara);
            return true;
        }
    }
}