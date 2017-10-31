using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using xsFramework.Web.WebPage;
using xsFramework.SqlServer;
namespace xs_System.Logic
{
    public class HireLogic 
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public string QueryHire()
        {
            return "select *  from [dbo].[xs_hire] ";
        }
        
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
        /// <summary>
        /// 更新招聘
        /// </summary>
        /// <returns></returns>
        public bool UpdateHire(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"update [xs_hire] set [hire_name]=@hire_name,[hire_count]=@hire_count,[hire_place]=@hire_place
                            ,[hire_remark]=@hire_remark where [hire_id]=@hire_id";
            SqlHelper.Execute(sqlpara);
            return true;
        }
        /// <summary>
        /// 招聘删除
        /// </summary>
        /// <returns></returns>
        public bool DeleteHire(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"delete from [xs_hire] where [hire_id]=@hire_id";
            SqlHelper.Execute(sqlpara);
            return true;
        }
        /// <summary>
        /// 查询单笔招聘
        /// </summary>
        /// <returns></returns>
        public DataTable QueryHire(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"select * from [dbo].[xs_hire] where [hire_id]=@hire_id";
            return SqlHelper.GetDataTable(sqlpara);
        }
        /// <summary>
        /// 查询招聘模板
        /// </summary>
        /// <returns></returns>
        public DataTable QueryHireTemplate()
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"select [hire_template_id],[hire_template_name],[hire_template_content]
                            from [dbo].[xs_hire_template]";
            return SqlHelper.GetDataTable(sqlpara);

        }
        /// <summary>
        /// 新增招聘模板
        /// </summary>
        /// <returns></returns>
        public bool AddHireTemplate(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"insert into [xs_hire_template]([hire_template_name],[hire_template_content])
                            values(@hire_template_name,@hire_template_content)";
            SqlHelper.Execute(sqlpara);
            return true;
        }
        /// <summary>
        /// 更新招聘模板
        /// </summary>
        /// <returns></returns>
        public bool UpdateHireTemplate(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"update [xs_hire_template] set [hire_template_name]=@hire_template_name,[hire_template_content]=@hire_template_content
                            where hire_template_id=@hire_template_id";
            SqlHelper.Execute(sqlpara);
            return true;
        }
        /// <summary>
        /// 删除招聘模板
        /// </summary>
        /// <returns></returns>
        public bool DeleteHireTemplate(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"delete from [xs_hire_template] 
                            where hire_template_id=@hire_template_id";
            SqlHelper.Execute(sqlpara);
            return true;
        }
    }
}