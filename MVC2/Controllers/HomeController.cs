using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC2.Models;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using MVC2.DAL;
using Newtonsoft.Json;

namespace MVC2.Controllers
{
    public class HomeController : Controller
    {
        private OnlineGameContext db = new OnlineGameContext();

        public ActionResult Index()
        {
            DateTime date = DateTime.Now;
            Student data = new Student();
            List<Student> list = new List<Student>();

            


            list.Add(new Student("1", "小明", 80));
            list.Add(new Student("2", "小華", 70));
            list.Add(new Student("3", "小英", 60));
            list.Add(new Student("4", "小李", 50));
            list.Add(new Student("5", "小張", 90));

            ViewBag.Date = date;
            ViewBag.Student = data;
            ViewBag.List = list;
            

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            DateTime date = DateTime.Now;
            ViewBag.Date = date;

            List<Gamer> cityList = db.Gamers.ToList();
            ViewBag.CityList = cityList;

            Student data = new Student("5", "小明", 80);
            return View(data);
        }

        [HttpGet]
        public ActionResult Transcripts(string id, string name, int score)
        {
            Student data = new Student(id, name, score);
            return View(data);
        }

        //[HttpPost]
        //public ActionResult Transcripts(FormCollection post)
        //{
        //    string id = post["id"];
        //    string name = post["name"];
        //    int score = Convert.ToInt32(post["score"]);
        //    Student data = new Student(id, name, score);
        //    return View(data);
        //}

        [HttpPost]
        public ActionResult Transcripts(Student model)
        {
          
            string id = model.id;
            string name = model.name;
            int score = model.score;
            Student data = new Student(id, name, score);
            return View(data);
        }

        [HttpPost]
        public ActionResult Village(string id = "")
        {
            GetVillageList getData = new GetVillageList();
            List<Gamer> list = getData.GetList(id);
            string result = "";
            if (list == null)
            {
                //讀取資料庫錯誤
                return Json(result);
            }
            else
            {
                result = JsonConvert.SerializeObject(list);
                return Json(result);
            }
        }
    }
}