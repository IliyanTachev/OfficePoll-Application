using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_App.Models;
using MVC_App.Models.Administrator;
using MVC_App.Data;
using MVC_App.Administrator;

public class CustomerController : Controller
{

    // GET: AnswerQuestion
    public ViewResult AnswerQuestion()
    {
        QuestionContext qt = new QuestionContext();
        ParentModel question = new ParentModel(false);
        try
        {
            question = qt.GetQuestionOfTheDay();
        }
        catch (MissingMemberException )
        {
            question.Question.Question = "There isn't question of the day ;(";
        }
        catch (Exception )
        {
            throw new Exception();
        }

        return View(question);
    }

    // GET: AnswerCharacteristics
    public ViewResult AnswerCharacteristics()
    {
        var charac = new CharacteristicsContext();
        ParentModel ch = new ParentModel();
        ch.CharacteristicsToAnswersCollection = charac.GetListOfAllCharacteristicsWithTheyAnswers();
        return View(ch);
    }

    // POST: AnswerCharacteristics
    [HttpPost]
    public ActionResult AnswerCharacteristics(ParentModel p)
    {

        return RedirectToAction("Finish");
    }

    public RedirectToRouteResult Index()
    {
        return RedirectToAction("AnswerQuestion", "Customer");
    }

    // GET: Finish
    public ViewResult Finish()
    {
        return View();
    }
}
