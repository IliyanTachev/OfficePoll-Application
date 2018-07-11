using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_App.Models;
using MVC_App.Administrator;

namespace MVC_App.Models.Administrator
{
    public class ParentModel
    {
        public ParentModel() { }
        public ParentModel(bool initializeQuestions = true)
        {
            AnswersCollection = new List<AnswerModel>();
            Question = new QuestionModel();
            if (initializeQuestions)
            {
                for (int i = 0; i < 5; i++)
                {
                    AnswersCollection.Add(new AnswerModel());
                }
            }
        }


        public List<AnswerModel> AnswersCollection { get; set; }
        public List<CharacteristicModel> CharacteristicsToAnswersCollection { get; set; }

        public QuestionModel Question { get; set; }


    }
}