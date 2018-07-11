using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_App.Models.Administrator
{
    public class AnswerToCharacteristicModel
    {
        String _text;
        int _char_id;

        public AnswerToCharacteristicModel() { }
        public AnswerToCharacteristicModel(String value, int char_id)
        {
            this._text = value;
            this._char_id = char_id;
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

        public int CharacteristicId
        {
            get
            {
                return this._char_id;
            }
            set
            {
                this._char_id = value;
            }
        }
    }
}