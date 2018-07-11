using MVC_App.Data;
using MVC_App.Models.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_App.Models;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using MVC_App.Administrator;
using System.Web.Helpers;

namespace MVC_App.Controllers.Administrator
{
    public class QuestionController : Controller
    {
        public QuestionController() { }
        // GET: Question
        public ViewResult Index()
        {
            return View(new QuestionContext().SelectAllQuestions());
        }

        // GET: Question/Details/5
        public ViewResult Details(int id)
        {

            ParentModel p = new ParentModel();
            p.Question =  new QuestionContext().SelectQuestion(id);
            p.AnswersCollection = new QuestionContext().SelectAnswers(id);
            

            return View(p);
        }

        // GET: Question/Create
        public ViewResult Create()
        {
            return View();
        }

        // POST: Question/Create
        [HttpPost]
        public ActionResult Create(ParentModel p)
        {
            try
            {

                // TODO: Add insert logic here
                AnswerToQuestionContext ans = new AnswerToQuestionContext();
                QuestionContext qt = new QuestionContext();

                int qId = ans.GetMaxId() + 1;
                DateTime date = DateTime.ParseExact(p.Question.Date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                qt.CreateQuestion(qId, p.Question.Question, date);


                foreach (var item in p.AnswersCollection)
                {
                    if (!string.IsNullOrWhiteSpace(item.Text))
                    {
                        ans.CreateAnswerToTheQuestions(qId, item.Text);
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Question/Edit/51
        public ViewResult Edit(int id)
        {
            ParentModel p = new ParentModel();
           
            p.Question =  new QuestionContext().SelectQuestion(id);
            p.AnswersCollection = new QuestionContext().SelectAnswers(id);


            return View(p);
        }


        // POST: Question/Edit/5
        [HttpPost]
        public ActionResult Edit( ParentModel p)
        {

            try
            {
                AnswerToQuestionContext ans = new AnswerToQuestionContext();
                QuestionContext qt = new QuestionContext();

                int qId = ans.GetMaxId() + 1;
                DateTime date = DateTime.ParseExact(p.Question.Date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                qt.CreateQuestion(qId, p.Question.Question, date);


                foreach (var item in p.AnswersCollection)
                {
                    if (!string.IsNullOrWhiteSpace(item.Text))
                    {
                        ans.CreateAnswerToTheQuestions(qId, item.Text);
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            ParentModel p = new ParentModel();
            p.Question = new QuestionContext().SelectQuestion(id);
            p.AnswersCollection = new QuestionContext().SelectAnswers(id);
            
            return View(p);
        }

        // POST: Question/Delete/5
        [HttpPost]
        public ActionResult Delete(QuestionModel q)
        {
            try
            {

                QuestionContext qt = new QuestionContext();
                qt.DeleteQuestion(q.id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void ExportContentToCSV()
        {
            StringWriter strw = new StringWriter();
            strw.WriteLine("question;count;gender;gender;years;years;years");
            Response.ClearContent();
            Response.AddHeader("content-disposition",
                string.Format("attachment;filename = File.csv"));
            Response.ContentType = "text/csv";

            for (int i = 0; i < 3; i++) { }
            strw.WriteLine("Do you like the coffee?;total;gender1;gender2;years1;years2;years3");
            strw.WriteLine("yes;30;10;4;5;3;3");
            strw.WriteLine("no;30;10;4;5;3;3");
            strw.WriteLine("maybe;30;10;4;5;3;3");

            Response.Write(strw.ToString());
            Response.End();
        }


        public ActionResult CreateChart(int id)
        {   
            //arr should be answers of question -- DB
            var arr = new string[] { "answ1", "answ2", "answ3", "answ4"};
            Chart myChart = new Chart(width: 600, height: 400)
                //Q name - DB
             .AddTitle("Do you like the coffee?");

            List<AnswerModel> a = new QuestionContext().SelectAnswers(id);
            foreach (var item in a){
                myChart.AddSeries(
                    name: item.Text,
                    //xValue - static
                    xValue: new[] { "<1", "1 - 3", "3 - 5", ">5", ">10" },
                    //yValue - from the DB Coun (*)
                    yValues: new[] { "2", "6", "4", "5", "3" })
                        .AddLegend();
            }
            myChart.Write("png");
            return null;
        }


    }
}
