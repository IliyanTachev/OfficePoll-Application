using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_App.Models.Administrator;

namespace MVC_App.Administrator
{
    public class QuestionModel 
    {
        public int id { get; set; }
        public String Question { get; set; }

        public String Date { get; set; }

        // public int Count { get; set; }
        // public List<AnswerModel> answers = new List<AnswerModel>();

      
    }
}