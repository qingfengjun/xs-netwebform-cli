//****************************************************************************************
//author xiaoshuai
//blog：http://www.cnblogs.com/xiaoshuai1992
//create: 2014/6/20
//function：the parameter of db out
//*****************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace xsFramework.SqlServer
{
    public class DbOutParameter
    {
        private DataSet _rtnDataset = new DataSet();//the return dataset 
        private DataTable _rtnDataTable = new DataTable();//the return datatable 
        private Dictionary<string, object> _dic = new Dictionary<string, object>();//the return parameter
        private int _exectFlag = 0;//execute flag

        public DataSet ReturnDataSet
        {
            set
            {
                _rtnDataset = value;
                if (value.Tables.Count > 0)
                {
                    _rtnDataTable = value.Tables[0];
                }
            }
            get { return _rtnDataset; }
        }

        public DataTable ReturnDataTable
        {
            get { return _rtnDataTable; }
        }
        public Dictionary<string, object> ReturnDic
        {
            get { return _dic; }
        }

        public int ExecteSuccess
        {
            set { _exectFlag = value; }
            get
            {
                return _exectFlag;
            }
        }
        /// <summary>
        ///the DBAccess to set return value
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="value">value</param>
        public void SetValue(string key, object value)
        {
            if (!_dic.ContainsKey(key))
            {
                _dic.Add(key, value);
            }
        }
    }

}
