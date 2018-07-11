using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_App.Models.Administrator
{
    public class CharacteristicModel
    {
        public CharacteristicModel(String value)
        {
            this._text = value;
        }

        public CharacteristicModel()
        {
        }

        public List<AnswerToCharacteristicModel> answers_to_characteristic = new List<AnswerToCharacteristicModel>();
        public int id { get; set; }
        public String _text;
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
    }
}