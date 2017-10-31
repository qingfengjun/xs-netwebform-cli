//****************************************************************************************
//author xiaoshuai
//blog：http://www.cnblogs.com/xiaoshuai1992
//create: 2014/6/20
//function：the parameter of db in
//*****************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace xsFramework.SqlServer
{
    public class DbInParameter
    {
        // sp is return dataset
        private bool _IsReturnDataSet = false;

        //set input parameter
        private List<SqlParameter> _sqlparas = new List<SqlParameter>();

        //the sql to command
        private string _sql = "";

        //the name of sp
        private string _storeProcureName = "";

        public bool IsReturnDataSet
        {
            set { _IsReturnDataSet = value; }
            get { return _IsReturnDataSet; }
        }
        public List<SqlParameter> SQLParameter
        {
            get { return _sqlparas; }
        }

        public string SQL
        {
            set { _sql = value; }
            get { return _sql; }
        }
        public string StoreProcureName
        {
            set { _storeProcureName = value; }
            get { return _storeProcureName; }
        }

        /// <summary>
        /// Add sqlParameter
        /// </summary>
        /// <param name="para"></param>
        public void AddParameter(SqlParameter para)
        {
            if (!_sqlparas.Contains(para))
            {
                _sqlparas.Add(para);
            }
        }
        public void AddParameter(List<SqlParameter> paras)
        {
            foreach (SqlParameter para in paras)
            {
                AddParameter(para);
            }
        }
    }
}

