using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DataAccess;
using DataModel;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WiredExam.Models;

namespace WiredExam.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Statu") == "-1")
            {
                ViewBag.Statu = -1;
            }

            if (HttpContext.Session.GetString("UserName") == "Hata")
            {
                ViewBag.Hata = "1";
            }
            return View();
        }

        //GİRİŞ KONTROL
        public ActionResult LoginControl(string Username, string Password)
        {
            UserDA uda = new UserDA();
            UserModel udm = new UserModel();
            if (Username != null && Password != null)
            {
                udm = uda.LoginControl(Username, Password);

                HttpContext.Session.SetString("UserID", (udm.ID).ToString());
                HttpContext.Session.SetString("UserName", udm.Username);
                HttpContext.Session.SetString("Statu", (udm.Statu).ToString());
                

                if (udm.Statu == -1)
                {
                    HttpContext.Session.SetString("Statu", "-1");
                    return RedirectToAction("Index");
                }
                else if (udm.Username != "Hata" && udm.Password != "Hata" && udm.Statu == 1)
                {

                    return RedirectToAction("Questions");
                }
                else if (udm.Username != "Hata" && udm.Password != "Hata" && udm.Statu == 2)
                {
                    HttpContext.Session.SetString("Statu", "2");
                    return RedirectToAction("Exams");
                }

                if (udm.Username=="Hata" && udm.Password == "Hata")
                {
                    HttpContext.Session.SetString("UserName", "Hata");
                    return RedirectToAction("Index");
                }
            }
            else
            {

               
                return RedirectToAction("Index");
            }

            return null;

        }

        //MAKALE SERVİS 
        public ActionResult Questions()
        {
            Uri url = new Uri("https://www.wired.com/most-recent/");
            WebClient client = new WebClient();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string html = client.DownloadString(url);

            HtmlAgilityPack.HtmlDocument dokuman = new HtmlAgilityPack.HtmlDocument();
            dokuman.LoadHtml(html);
            HtmlNodeCollection basliklar = dokuman.DocumentNode.SelectNodes("//li[@class='archive-item-component']");
            String[] linkler = new string[5];
            int i = 0;
            foreach (var baslik in basliklar)
            {
                if (i == 5)
                {
                    break;
                }



                //string ReplaceString = baslik.OuterHtml.Replace("\"", "'");
                int LinkBasla = baslik.OuterHtml.IndexOf("href=");
                int LinkBitir = baslik.OuterHtml.IndexOf("<div class=\"archive-item-component__img\">");
                string link = baslik.OuterHtml.Substring(LinkBasla + 7, LinkBitir - LinkBasla-10);
                //link = link.Substring(0, link.Length - 34);
                linkler[i] = link;
                i++;

            }

            List<QuestionsModel> questList = new List<DataModel.QuestionsModel>();
            for (int j = 0; j < 5; j++)
            {

                Uri NewURL = new Uri("https://www.wired.com/" + linkler[j]);
                WebClient newClient = new WebClient();
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string NewHtml = newClient.DownloadString(NewURL);

                HtmlAgilityPack.HtmlDocument NewDokuman = new HtmlAgilityPack.HtmlDocument();
                NewDokuman.LoadHtml(NewHtml);
                HtmlNodeCollection NewBaslik = NewDokuman.DocumentNode.SelectNodes("//h1[@id='articleTitleFull']");
                HtmlNodeCollection NewDescription = NewDokuman.DocumentNode.SelectNodes("//p");

                /*
                 * &#39; --> ' 
                 * &amp; --> & 
                 */
                if (NewBaslik != null)
                {
                    QuestionsModel qq = new DataModel.QuestionsModel();
                    qq.Topic = NewBaslik.ElementAt(0).InnerHtml.Replace("&#39;", "'");
                    qq.Topic = qq.Topic.Replace("&amp;", "&");
                    qq.Ask = NewDescription.ElementAt(0).InnerText;
                    questList.Add(qq);

                }
                if (NewBaslik == null)
                {
                    NewBaslik = NewDokuman.DocumentNode.SelectNodes("//h1[@class='content-header__row content-header__hed']");
                    if (NewBaslik != null)
                    {
                        QuestionsModel qq = new DataModel.QuestionsModel();
                        qq.Topic = NewBaslik.ElementAt(0).InnerHtml.Replace("&#39;", "'");
                        qq.Topic = qq.Topic.Replace("&amp;", "&");
                        qq.Ask = NewDescription.ElementAt(0).InnerText;
                        questList.Add(qq);

                    }
                }

            }

            ViewData["Liste"] = questList;
            HttpContext.Session.SetString("Liste", JsonConvert.SerializeObject(questList));

            return View(questList);
        }

        //SINAV AÇIKLAMA GETİR
        public string GetAsk(string ID)
        {
            string deger = ID;
            var sira = Convert.ToInt32(ID);
            var liste = HttpContext.Session.GetString("Liste");
            if (liste != null)
            {
                var degerListesi = JsonConvert.DeserializeObject<List<DataModel.QuestionsModel>>(liste);
                deger = degerListesi[sira].Ask;

            }
            return deger;
        }

        //SINAV EKLE
       
        public ActionResult AddExam(QuestionsModel qts)
        {

            QuestionsDA qda = new QuestionsDA();
            qda.AddExam(qts);
            return RedirectToAction("Questions");
        }

        //SINAV LİSTESİ
        public ActionResult Exams()
        {
            if (HttpContext.Session.GetString("Statu") == "2")
            {
                ViewBag.Statu = "2";
            }

            QuestionsDA qda = new QuestionsDA();
            List<QuestionsModel> questList = new List<DataModel.QuestionsModel>();

            questList = qda.ListQuestions();
            return View(questList);
        }

        //SINAV SİL
        public ActionResult DeleteExam(string ID)
        {

            QuestionsDA qda = new QuestionsDA();

            qda.DeleteExam(Convert.ToInt32(ID));
            return RedirectToAction("Exams");
        }

        //SINAV DETAY SAYFASI
        public ActionResult DetailExam(string ID)
        {

            QuestionsDA qda = new QuestionsDA();
            DataModel.QuestionsModel qdm = new DataModel.QuestionsModel();
            qdm = qda.DetailExam(Convert.ToInt32(ID));

            return View(qdm);
        }

        //DOĞRU CEVAP KONTROL
        public JsonResult ControlReply(string q1, string q2, string q3, string q4, string ID)
        {
            QuestionsDA qda = new QuestionsDA();
            DataModel.QuestionsModel qdm = new DataModel.QuestionsModel();
            qdm = qda.DetailExam(Convert.ToInt32(ID));

            return Json(new { success = true, data = qdm });
            //return Json(qdm);
        }



        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
