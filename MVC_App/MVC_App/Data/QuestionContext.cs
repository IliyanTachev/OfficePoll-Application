using MVC_App.Models.Administrator;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using MVC_App.Models;
using MVC_App.Administrator;

namespace MVC_App.Data
{
    public class QuestionContext : DbContext
    {

        OfficePoll2Entities entities = new OfficePoll2Entities();

        public void CreateQuestion(int q_id, String txt, DateTime date)
        {

            try
            {
                using (entities)
                {
                    entities.Questions.Add(new Questions() { id = q_id, text = txt, date = date});
                    entities.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteQuestion(int id)
        {
            try
            {
                using (OfficePoll2Entities entities = new OfficePoll2Entities())
                {
                    var question = entities.Questions.Find(id);
                    IQueryable<Answers_to_the_Questions> answers = entities.Answers_to_the_Questions.Where(item => item.question_id == question.id);
                    foreach (var a in answers)
                    {
                        var ans = entities.Answers_to_the_Questions.Find(a.id);
                        entities.Answers_to_the_Questions.Remove(ans);
                    }

                    entities.Questions.Remove(question);
                    entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateQuestion(int id, String text, String Date)
        {
            using (entities)
            {
                var question = entities.Questions.Find(id);
                question.text = text;
                question.id = id;
                question.date = DateTime.ParseExact(Date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                entities.SaveChanges();

            }
        }

        public QuestionModel SelectQuestion(int id)
        {
            QuestionModel q = new QuestionModel();
            using (entities)
            {

                Questions question = entities.Questions.Find(id);
                q.Question = question.text;
                q.id = question.id;
                q.Date = question.date.ToString();
                //q.Count = CountOfAnswers(question.id);
                //q.answers = SelectAnswers(question.id);
            }
            return q;
        }
        // it is used for list of the questions
        public List<QuestionModel> SelectAllQuestions()
        {
            List<QuestionModel> qList = new List<QuestionModel>();
            using (entities)
            {
                foreach (var q in entities.Questions)
                {
                    QuestionModel temp = new QuestionModel();
                    temp.id = q.id;
                    temp.Question = q.text;
                    temp.Date = q.date.ToShortDateString();
                         //temp.answers = null;
                    qList.Add(temp);
                }

            }
            return qList;
        }

        
        public ParentModel GetQuestionOfTheDay()
        {
             ParentModel result = new ParentModel(initializeQuestions: false);
             try
             {
                 using (OfficePoll2Entities entities = new OfficePoll2Entities())
                 {
                     var questionOfTheDay = entities.Questions.FirstOrDefault(q => q.date == DateTime.Today);
                     //System.Diagnostics.Debug.WriteLine(DateTime.Today);
                     //var question = questions.First();
                     if (questionOfTheDay != null)
                     {
                         result.Question.Question = questionOfTheDay.text;
                         result.Question.id = questionOfTheDay.id;
                         result.Question.Date = questionOfTheDay.date.ToShortDateString(); // to format
                         var answers = entities.Answers_to_the_Questions.Where(a => a.question_id == questionOfTheDay.id);

                         foreach (var item in answers)
                         {
                             result.AnswersCollection.Add(new AnswerModel() { QuestionId = item.question_id, Text = item.text });
                         }
                     }
                     else
                     {
                         throw new MissingMemberException("There isn't question of the day!");
                     }
                 }
             }
             catch (MissingMemberException missing)
             {
                 if (missing.Message.Equals("There isn't question of the day!"))
                 {
                     throw missing;
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }

             return result;
         
        }
      
        
        public List<AnswerModel> SelectAnswers(int q_id)
        {
            List<AnswerModel> qList = new List<AnswerModel>();
            using (entities)
            {
                IQueryable<Answers_to_the_Questions> answers = entities.Answers_to_the_Questions.Where(item => item.question_id == q_id);
                foreach (var a in answers)
                {
                    AnswerModel ans = new AnswerModel();
                    ans.Text = a.text;
                    qList.Add(ans);
                }
            }
            return qList;
        }

        public int CountOfAnswers(int q_id)
        {
            int count = 0;
            using (entities)
            {
                count = entities.Answers_to_the_Questions.Where(item => item.question_id == q_id).Count();
      
            }
            return count;
        }
    }
}