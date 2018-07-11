using MVC_App.Models.Administrator;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_App.Data
{
    public class AnswerToQuestionContext
    {
        public void CreateAnswerToTheQuestions(int q_id, String text) {
            using(OfficePoll2Entities entities = new OfficePoll2Entities())
            {
                entities.Answers_to_the_Questions.Add(new Answers_to_the_Questions() {question_id = q_id,  text = text, type = 1});
                entities.SaveChanges();

            }
        }

        public void UpdateAnswerToTheQuestions(int id, String text)
        {
            using (OfficePoll2Entities entities = new OfficePoll2Entities())
            {
                var answerToUpdate = entities.Answers_to_the_Questions.Find(id);
                answerToUpdate.text = text;
                entities.SaveChanges();
                
            }
        }

        public void DeleteAnswerToTheQuestions(int id)
        {
            using (OfficePoll2Entities entities = new OfficePoll2Entities())
            {

                var answerToDelete = entities.Answers_to_the_Questions.Find(id);
                entities.Answers_to_the_Questions.Remove(answerToDelete);
                entities.SaveChanges();

            }
        }

        public AnswerModel SelectAnswerToTheQuestions(int id)
        {
           
            using (OfficePoll2Entities entities = new OfficePoll2Entities())
            {
                Answers_to_the_Questions answer = entities.Answers_to_the_Questions.Find(id);
                AnswerModel ans = new AnswerModel( answer.text);

                return ans;

            }
        }

        public int GetMaxId() {
            int id = 0; 
            using (OfficePoll2Entities entities = new OfficePoll2Entities())
            {
                try
                {
                    id = entities.Questions.Max(q => q.id);
                   
                }
                catch (Exception)
                {

                    id = 0;
                }
                
            }
            return id;
        }
    }
}
