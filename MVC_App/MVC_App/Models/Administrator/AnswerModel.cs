using MVC_App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_App.Models.Administrator
{
    public class AnswerModel 
    {

        public AnswerModel(){}

        public AnswerModel(String value) {
            this._text = value;
        }
        

        String _text;
        int _questionId;
        int _id;
        public int id {
            get {
                     return this._id;
                }
           set {
                this._id = value;
            }
        }
        public String Text
        {
            get
            {
                return this._text;
            }
             set
            {
                this._text = value;
            }
        }

        public int QuestionId
        {
            get
            {
                return this._questionId;
            }
            set
            {
                this._questionId = value;
            }
        }
    }
}