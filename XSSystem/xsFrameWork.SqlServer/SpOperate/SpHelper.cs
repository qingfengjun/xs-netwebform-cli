//****************************************************************************************
//author xiaoshuai
//blog：http://www.cnblogs.com/xiaoshuai1992
//create: 2014/6/20
//function：operate db whith sp
//*****************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace xsFramework.SqlServer
{
    public class SpHelper
    {
        public static DbOutParameter ExecuteSP(xsSpParameter spPara)
        {
            DbInParameter dbInPara = new DbInParameter();
            DbOutParameter dbOutPara = new DbOutParameter();
            dbInPara.StoreProcureName = spPara.SPName;//set sp name
            dbInPara.IsReturnDataSet = spPara.IsReturnDataSet;//set sp return 
            dbInPara.AddParameter(spPara.SpParameters);//set spparameter
            DbAccess Dao = new DbAccess();
            Dao.Open(spPara.SqlConnectString);
            dbOutPara = Dao.ExecProcedure(dbInPara);
            Dao.Close();
            return dbOutPara;
        }
        public static DataSet GetDataSet(xsSpParameter spPara)
        {
            spPara.IsReturnDataSet = true;//must reurn dataset ,set true 
            return ExecuteSP(spPara).ReturnDataSet;
        }
        public static DataTable GetDataTable(xsSpParameter spPara)
        {
            spPara.IsReturnDataSet = true;//must reurn dataset ,set true 
            return ExecuteSP(spPara).ReturnDataTable;
        }
    }
}
