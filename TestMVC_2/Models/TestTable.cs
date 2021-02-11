using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TestMVC.SqlDBClass;
namespace TestMVC.Models
{
    public class TestTable
    {
        public int STATE_ID { get; set; }
        public string STATE_NAME { get; set; }

        public List<TestTable> getTestTable()
        {
            try
            {
                DataTable dt = new DataTable();
                List<TestTable> lst = new List<TestTable>();
                dt = new SqlDBInstance().getDatatable("SELECT S_ID,STATE_NAME FROM TEST_TABLE");
                foreach (DataRow w in dt.Rows)
                {
                    lst.Add(new TestTable()
                    {
                        STATE_ID = Convert.ToInt32(w[0].ToString()),
                        STATE_NAME = w[1].ToString()
                    });
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

    public class ViewTestTable
    {
        public IEnumerable<TestTable> viewTestTable { get; set; }
    }

    public class UserData
    {
        public String USER_NAME { get; set; }
        public String USER_PS { get; set; }
    }
}