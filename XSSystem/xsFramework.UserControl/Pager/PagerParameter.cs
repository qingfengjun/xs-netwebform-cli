using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xsFramework.UserControl.Pager
{
    public class PagerParameter
    {
        private xsPageControl xspager = new xsPageControl();

        public xsPageControl XsPager
        {
            get { return xspager; }
            set { xspager = value; }
        }
        private string sql = "";

        public string Sql
        {
            get { return sql; }
            set { sql = value; }
        }
        private string dbConn = "";

        public string DbConn
        {
            get { return dbConn; }
            set { dbConn = value; }
        }
        private string orderBy = "";

        public string OrderBy
        {
            get { return orderBy; }
            set { orderBy = value; }
        }

    }
}
