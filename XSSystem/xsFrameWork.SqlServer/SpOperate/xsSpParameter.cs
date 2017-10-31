//****************************************************************************************
//author xiaoshuai
//blog：http://www.cnblogs.com/xiaoshuai1992
//create: 2014/6/20
//function：the parameter of operate db whith sp
//*****************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace xsFramework.SqlServer
{
    public class xsSpParameter
    {
        private string _spName = "";//sp name
        private string _connstring = "";// db connect string
        private bool _isReturnDataSet = false;// sp return dataset
        private List<SqlParameter> _sqlPara = new List<SqlParameter>();//sqlparameters

        /// <summary>
        /// SP Name
        /// </summary>
        public string SPName
        {
            set { _spName = value; }
            get { return _spName; }
        }

        /// <summary>
        /// DB Connection string
        /// </summary>
        public string SqlConnectString
        {
            set { _connstring = value; }
            get { return _connstring; }
        }

        /// <summary>
        /// SP return DataSet or DataTable
        /// </summary>
        public bool IsReturnDataSet
        {
            set { _isReturnDataSet = value; }
            get { return _isReturnDataSet; }
        }
        /// <summary>
        /// sp sqlparameter
        /// </summary>
        public List<SqlParameter> SpParameters
        {
            get { return _sqlPara; }
        }

        #region sqlparameter
        /// <summary>
        /// add sqlparameter
        /// </summary>
        /// <param name="para"></param>
        public void AddSqlParameter(SqlParameter para)
        {
            //exist delete then add
            DeleteSqlParameter(para.ParameterName);
            _sqlPara.Add(para);

        }

        /// <summary>
        /// delete on of the sqlparameters
        /// </summary>
        /// <param name="key"></param>
        public void DeleteSqlParameter(string key)
        {

            foreach (SqlParameter para in _sqlPara)
            {
                if (key.Equals(para.ParameterName))
                {
                    _sqlPara.Remove(para);
                    break;
                }
            }
        }
        /// <summary>
        /// delete all sqlparameters
        /// </summary>
        public void ClearSqlParameter()
        {
            _sqlPara.Clear();
        }
        #endregion

    }
}
