using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using xsFramework.Web.WebPage;
using xsFramework.SqlServer;
namespace xs_System.Logic
{
    public class ProductLogic    {
        /// <summary>
        /// 加入产品
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public bool InsertProduct(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"insert into xs_product(product_title,product_remark,product_content,product_imgurl,
                            product_type_id,product_create_time,[product_create_user],product_update_time,product_update_user)
                            values
                            (@product_title,@product_remark,@product_content,@product_imgurl,
                            @product_type_id,getdate(),@product_create_user,getdate(),@product_create_user)";
            SqlHelper.Execute(sqlpara);
            return true;
        }
        /// <summary>
        /// 更新产品
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public bool UpdateProduct(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"update dbo.xs_product set
                            [product_title]=@product_title
                            ,[product_remark]=@product_remark
                            ,[product_content]=@product_content
                            ,[product_type_id]=@product_type_id
                            ,[product_update_time]=GETDATE()
                            ,[product_update_user]=@product_update_user
                            ,product_imgurl=@product_imgurl
                            where product_id=@product_id";
            SqlHelper.Execute(sqlpara);
            return true;
        }
        /// <summary>
        /// 根据页码查询产品
        /// </summary>
        /// <returns></returns>
        public string QueryProducts(string strType, string strName)
        {
            string sql= "select product_id,product_title,product_remark,product_imgurl from dbo.xs_product where 1=1 ";
            if (!string.IsNullOrEmpty(strType)) sql += " and product_type_id='" + strType + "'";
            if (!string.IsNullOrEmpty(strName)) sql += " and product_title like '%" + strName + "%'";
            return sql;
        }

        /// <summary>
        /// 查询商品
        /// </summary>
        /// <returns></returns>
        public DataTable QueryProductByID( string strID)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.AddSqlParameter("@product_id", strID);
            sqlpara.SQL = @"SELECT  [product_id]
                              ,[product_title]
                              ,[product_remark]
                              ,[product_content]
                              ,[product_imgurl]
                              ,[product_type_id]
                              ,[product_create_time]
                              ,[product_create_user]
                          FROM [dbo].[xs_product] where product_id=@product_id ";
            return SqlHelper.GetDataTable(sqlpara);
        }
        /// <summary>
        /// 删除产品类别
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public bool DeleteProduct(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"delete from [dbo].[xs_product] where product_id=@product_id";
            SqlHelper.Execute(sqlpara);
            return true;
        }

        /// <summary>
        /// 查询商品类别
        /// </summary>
        /// <returns></returns>
        public DataTable QueryProductType()
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"select * from [dbo].[xs_product_type]";
            return SqlHelper.GetDataTable(sqlpara);
        }
        /// <summary>
        /// 新增产品类别
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public bool InsertProductType(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"insert into xs_product_type([product_type_id],[product_type_name],[product_type_remark])
                                values(@producttype_id,@producttype_name,@producttype_remark)";
            SqlHelper.Execute(sqlpara);
            return true;
        }
        /// <summary>
        /// 更新产品类别
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public bool UpdateProductType(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"update xs_product_type set [product_type_name]=@producttype_name,[product_type_remark]=@producttype_remark
                            where [product_type_id]=@producttype_id";
            SqlHelper.Execute(sqlpara);
            return true;
        }
        /// <summary>
        /// 删除产品类别
        /// </summary>
        /// <param name="dml"></param>
        /// <returns></returns>
        public bool DeleteProductType(DirModel dml)
        {
            xsSqlParameter sqlpara = new xsSqlParameter();
            sqlpara.AddSqlParameter(dml);
            sqlpara.SqlConnectString = GlabalString.DBString;
            sqlpara.SQL = @"delete from  xs_product_type  where [product_type_id]=@producttype_id
                            delete from [dbo].[xs_product] where [product_type_id]=@producttype_id";
            SqlHelper.Execute(sqlpara);
            return true;
        }
    }
}