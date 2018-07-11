using MVC_App.Administrator;
using MVC_App.Models.Administrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_App.Models.Customer
{
    public class CustomerParentModel
    { 

        public QuestionModel Question { get; set; }

        public List<AnswerModel> AnswerToQuestion { get; set; }

        public CharacteristicModel Characteristics { get; set; }

        public List<AnswerToCharacteristicModel> AnswerToCharacteristics { get; set; }


    }
}