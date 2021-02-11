using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;
namespace TestMVC.Controllers
{
    public class TopicController : Controller
    {
        [HttpPost]
        // GET: Topic
        public ActionResult TopicView()
        {
            ViewBag.slot_name = "Study Topics For Today : 10-02-2021";
            ViewBag.tid= Request["Topic_ID"].ToString();
            string topic_id = (string)ViewBag.tid;
            Console.WriteLine("Topic_ID : " + topic_id);
            ViewTopic lstTp = new ViewTopic();
            lstTp.lstTopic = new CoreTest().getTopic(topic_id);
            return View(lstTp);
        }
    }
}