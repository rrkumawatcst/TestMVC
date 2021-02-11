using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using TestMVC.SqlDBClass;

namespace TestMVC.Models
{
    public class Topic
    {
        public String TOPIC_ID { get; set; }
        public String TOPIC_NAME { get; set;}
        public String TOPIC_TEXT { get; set; }
        public String CRNT_DATE { get; set; }
        public String NEXT_DATE { get; set; }
        public String INTERVAL { get; set; }
    }
    public class CoreTest
    {
        SqlDBInstance instance;
        DataTable dt;

        public List<Topic> getTopic(string topic_id)
        {
            try
            {
                instance = new SqlDBInstance();
                List<Topic> topic = new List<Topic>();
                dt = new DataTable();
                string cmd_get = @"SELECT t.T_ID,t.Topic_Name,t.Topic_Txt,s.CRNT_DATE,s.NEXT_DATE,s.INTERVAL_COUNT 
                                    FROM Tbl_GLP_Topic t
                                    inner join tblSpaceRepatation s on t.T_ID = s.TOPIC_ID";
                dt = instance.getDatatable(cmd_get);
                foreach(DataRow w in dt.Rows)
                {
                    topic.Add(new Topic()
                    {
                        TOPIC_ID = w[0].ToString(),
                        TOPIC_NAME = w[1].ToString(),
                        TOPIC_TEXT = w[2].ToString(),
                        CRNT_DATE = Convert.ToDateTime(w[3]).ToString("dd-MM-yyyy"),
                        NEXT_DATE = Convert.ToDateTime(w[4]).ToString("dd-MM-yyyy"),
                        INTERVAL = w[5].ToString()
                    });
                }
                return topic;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message+"\n"+ex.StackTrace);
            }
        }

    }

    public class ViewTopic
    {
        public IEnumerable<Topic> lstTopic { get; set; }
    }
}