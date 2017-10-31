//****************************************************************************************
//author xiaoshuai
//blog：http://www.cnblogs.com/xiaoshuai1992
//create: 2014/6/20
//function：operate of db
//*****************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace xsFramework.SqlServer
{
    public class DbAccess
    {
        private SqlTransaction trans = null;
        private SqlCommand sqlcomm = null;
        private SqlConnection sqlconn = null;

        public enum DBStatus
        {
            Open,
            Close,
            Begin_Trans,
            Commit_Trans,
            RollBack_Trans,
            Empty
        }
        protected DBStatus _s = DBStatus.Empty;


        /// <summary>
        /// Open SqlServer
        /// </summary>
        /// <param name="connString"></param>
        public void Open(string connString)
        {
            if (sqlconn == null)
            {
                this.sqlconn = new SqlConnection(connString);
            }
            if (this.sqlconn.State != ConnectionState.Open)
            {
                this.sqlconn.Open();
            }
            this._s = DBStatus.Open;
        }

        /// <summary>
        /// Close SqlServer
        /// </summary>
        public void Close()
        {
            if (this.sqlconn != null && this.sqlconn.State == ConnectionState.Open)
            {
                this.sqlconn.Close();
            }
            this.sqlconn = null;
            this._s = DBStatus.Close;
        }

        /// <summary>
        /// Exec Procedure
        /// </summary>
        public DbOutParameter ExecProcedure(DbInParameter _DbInParameter)
        {
            DbOutParameter rtn = new DbOutParameter();
            if (this._s == DBStatus.Begin_Trans)
            {
                sqlcomm = new SqlCommand(_DbInParameter.StoreProcureName, this.sqlconn, this.trans);
            }
            else
            {
                sqlcomm = new SqlCommand(_DbInParameter.StoreProcureName, this.sqlconn);
            }
            sqlcomm.CommandType = CommandType.StoredProcedure;
            // sqlcomm.CommandTimeout = 10000000;
            foreach (SqlParameter sp in _DbInParameter.SQLParameter)
            {
                sqlcomm.Parameters.Add(sp);
            }

            try
            {
                if (_DbInParameter.IsReturnDataSet)
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    sqlDa.SelectCommand = sqlcomm;
                    sqlDa.Fill(ds);
                    rtn.ReturnDataSet = ds;
                }
                else
                {
                    rtn.ExecteSuccess = sqlcomm.ExecuteNonQuery(); // success >0
                }

                //get parameter of out
                foreach (SqlParameter sp in sqlcomm.Parameters)
                {
                    if (sp.Direction == ParameterDirection.Output || sp.Direction == ParameterDirection.InputOutput || sp.Direction == ParameterDirection.ReturnValue)
                    {
                        if (!rtn.ReturnDic.ContainsKey(sp.ParameterName))
                        {
                            rtn.ReturnDic.Add(sp.ParameterName, sp.Value);

                        }
                    }
                }
            }
            finally
            {
                sqlcomm.Cancel();
                sqlcomm = null;
            }
            return rtn;

        }
        /// <summary>
        /// Begin Trans
        /// </summary>
        public void BeginTrans()
        {
            this.trans = this.sqlconn.BeginTransaction();
            this._s = DBStatus.Begin_Trans;
        }
        /// <summary>
        /// RollBack Trans
        /// </summary>
        public void RollBack()
        {
            this.trans.Rollback();
            this._s = DBStatus.RollBack_Trans;
        }

        public void Commit()
        {
            if (this._s == DBStatus.Begin_Trans)
            {
                this.trans.Commit();
                this._s = DBStatus.Commit_Trans;
            }
        }

        /// <summary>
        ///  sql of ExecuteNoQuery
        /// </summary>
        /// <param name="_DbInParameter"></param>
        public void ExecuteNoQuery(DbInParameter _DbInParameter)
        {
            if (sqlcomm == null)
            {
                sqlcomm = new SqlCommand(_DbInParameter.SQL, this.sqlconn);
                //sqlcomm.CommandTimeout = 10000000;
            }
            else
            {
                sqlcomm.CommandText = _DbInParameter.SQL;
            }

            if (_DbInParameter.SQLParameter != null)
            {
                foreach (SqlParameter sp in _DbInParameter.SQLParameter)
                {
                    sqlcomm.Parameters.Add(sp);
                }
            }

            if (_s == DBStatus.Begin_Trans)
                sqlcomm.Transaction = this.trans;

            try
            {
                sqlcomm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlcomm.Cancel();
                sqlcomm = null;
            }
        }

        /// <summary>
        /// Get data 
        /// </summary>
        /// <param name="_DbInParameter"></param>
        /// <returns></returns>
        public DbOutParameter ExecuteQuery(DbInParameter _DbInParameter)
        {
            DbOutParameter rtn = new DbOutParameter();
            if (sqlcomm == null)
            {
                sqlcomm = new SqlCommand(_DbInParameter.SQL, this.sqlconn);
                //sqlcomm.CommandTimeout = 10000000;
            }
            else
            {
                sqlcomm.CommandText = _DbInParameter.SQL;
            }

            if (_DbInParameter.SQLParameter != null)
            {
                foreach (SqlParameter sp in _DbInParameter.SQLParameter)
                {
                    sqlcomm.Parameters.Add(sp);
                }
            }

            if (_s == DBStatus.Begin_Trans)
                sqlcomm.Transaction = this.trans;

            try
            {
                SqlDataAdapter sqlDa = new SqlDataAdapter();
                DataSet ds = new DataSet();
                sqlDa.SelectCommand = sqlcomm;
                sqlDa.Fill(ds);
                rtn.ReturnDataSet = ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlcomm.Cancel();
                sqlcomm = null;
            }
            return rtn;
        }

        /// <summary>
        /// 把数据批量插入到数据库中
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="tableName"></param>
        /// <param name="sqlconn">数据库连接</param>
        public void ExecuteTransactionScopeInsertEx(DataTable dt, string tableName)
        {
            try
            {
                using (SqlBulkCopy sbc = new SqlBulkCopy(sqlconn, SqlBulkCopyOptions.TableLock, trans))
                {        //服务器上目标表的名称         
                    sbc.DestinationTableName = tableName;
                    sbc.BatchSize = dt.Rows.Count;
                    sbc.BulkCopyTimeout = 600;
                    for (int i = 0, l = dt.Columns.Count; i < l; i++)
                    {            //列映射定义数据源中的列和目标表中的列之间的关系    
                        sbc.ColumnMappings.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                    }
                    sbc.WriteToServer(dt);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
