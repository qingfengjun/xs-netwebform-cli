using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using xsFramework.SqlServer;
using xsFramework.Web.WebPage;

namespace xs_System.Logic
{
    public class groupLogic
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public string QueryGroup()
        {
            return "select *   from [xs_group]  where group_id<>'G001'";
        }
        /// <summary>
        /// 新增群组
        /// </summary>
        /// <returns></returns>
        public bool AddGroup(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"insert into [xs_group]([group_id],[group_name],[group_remark])values(@group_id,@group_name,@group_remark)";
            SqlHelper.Execute(sqlpara);
            return true;

        }
        /// <summary>
        /// 更新群组
        /// </summary>
        /// <returns></returns>
        public bool UpdateGroup(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"update [xs_group] set [group_name]=@group_name,[group_remark]=@group_remark where [group_id]=@group_id";
            SqlHelper.Execute(sqlpara);
            return true;
           
        }
        /// <summary>
        /// 删除群组
        /// </summary>
        /// <returns></returns>
        public bool DeleteGroup(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"update [dbo].[xs_group_user] set [group_id]='G000' where [group_id]=@group_id
                            delete from [xs_group] where [group_id]=@group_id
                            delete from dbo.xs_group_user where [group_id]=@group_id
                            delete from dbo.xs_group_function  where [group_id]=@group_id   ";
            SqlHelper.Execute(sqlpara);
            return true;

        }
        /// <summary>
        /// 通过id查询所有信息
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public DataTable QueryGroupByID(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"select * from  [dbo].[xs_group] where [group_id]=@group_id";
            return SqlHelper.GetDataTable(sqlpara);


        }
        /// <summary>
        /// 是否存在群组名称
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public bool ExistGroup(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"select * from  [dbo].[xs_group] where [group_id]<>@group_id and [group_name]=@group_name";
            return SqlHelper.Exist(sqlpara);

        }
        /// <summary>
        /// 查询群组功能所有的数据源
        /// </summary>
        /// <param name="dml"></param>
        /// <param name="ICount"></param>
        /// <returns></returns>
        public DataSet QueryGroupFunction(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"select [function_id],[function_name],[function_level],[function_sort],[function_action],[function_parent_id] from [dbo].[xs_function]
                            where [function_inmenu]=1

                            select [action_id],[action_name] from [dbo].[xs_action]

                            select * from .[xs_group_function]   where [group_id]=@group_id";
            return SqlHelper.GetDataSet(sqlpara);
            
        }

        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="strID"></param>
        /// <returns></returns>
        public bool InsetDataTable(DataTable dt, string strID)
        {
            
            DbInParameter si = new DbInParameter();
            DbOutParameter sr = new DbOutParameter();
            DbAccess dao = new DbAccess();
            si.SQL = "delete from xs_group_function where [group_id]='" + strID + "'";
            si.IsReturnDataSet = true;
            dao.Open(GlabalString.DBString);
            dao.BeginTrans();
            dao.ExecuteNoQuery(si);
            dao.ExecuteTransactionScopeInsertEx(dt, "xs_group_function");
            dao.Commit();
            dao.Close();
            return true;



        }
    }
}