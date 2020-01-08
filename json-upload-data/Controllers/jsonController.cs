using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json;

namespace json_upload_data.Controllers
{
    public class jsonController : Controller
    {
        //
        // GET: /json/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult uploadjson(HttpPostedFileBase filejson)
        {
            SampleDBEntities sd = new SampleDBEntities();
            {
                if(!filejson.FileName.EndsWith(".json"))
                {

                    ViewBag.errmsg = "Only JSON Type Files Allowed";              
                }
                else
                {
                    filejson.SaveAs(Server.MapPath("~/empfolder/" + Path.GetFileName(filejson.FileName)));
                    StreamReader reader = new StreamReader(Server.MapPath("~/empfolder/" + Path.GetFileName(filejson.FileName)));
                    string jsondata = reader.ReadToEnd();
                    List<empjsondata> emplist = JsonConvert.DeserializeObject<List<empjsondata>>(jsondata);
                    foreach (var item in emplist)
                    {
                        @item.email.ToString();
                        @item.EmpName.ToString();
                        @item.salary.ToString();
                        sd.empjsondatas.Add(item);
                        sd.SaveChanges();
                    }
                    ViewBag.message = "Selected" +  Path.GetFileName(filejson.FileName) + "File  Is Saved Successfully !";
                }
            }
            return View ("Index");
        }
	}
}