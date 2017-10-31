//****************************************************************************************
//author xiaoshuai
//blog：http://www.cnblogs.com/xiaoshuai1992
//create: 2014/6/20
//function：the parameter of operate db whith sql
//*****************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace xsFramework.SqlServer
{
    public class xsSqlParameter
    {
        private string _sql = "";
        private List<SqlParameter> _sqlPara = new List<SqlParameter>();//parameters
        private string _connstring = "";// db connect string

        public string SQL
        {
            set { _sql = value; }
            get { return _sql; }
        }
        public List<SqlParameter> SqlPara
        {
            get { return _sqlPara; }
        }
        public string SqlConnectString
        {
            set { _connstring = value; }
            get { return _connstring; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="paraValue"></param>
        public void AddSqlParameter(string paraName, object paraValue)
        {

            bool IsExist = false;
            foreach (SqlParameter para in _sqlPara)
            {
                if (paraName.Equals(para.ParameterName))
                {
                    IsExist = true;
                    para.Value = paraValue;//exist cover
                    break;
                }
            }
            if (!IsExist)
            {
                _sqlPara.Add(new SqlParameter(paraName, paraValue));
            }
        }

        /// <summary>
        ///  use to recive the parameter from page
        /// </summary>
        /// <param name="dirs"></param>
        public void AddSqlParameter(Dictionary<string, object> dirs)
        {
            foreach (KeyValuePair<string, object> dir in dirs)
            {
                AddSqlParameter(dir.Key, dir.Value);
            }
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
    }
}
