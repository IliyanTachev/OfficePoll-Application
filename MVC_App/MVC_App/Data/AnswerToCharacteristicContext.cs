using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_App.Data
{
    public class AnswerToCharacteristicContext
    {
        public void CreateAnswerToCharacteristic(String txt, int char_id)
        {
            using (OfficePoll2Entities entities = new OfficePoll2Entities())
            {
                entities.Answers_to_the_Characteristics
                    .Add(new Answers_to_the_Characteristics() { text = txt, characteristic_id = char_id });
                entities.SaveChanges();

            }
        }

        public void UpdateAnswerToCharacteristic(int id, String text, int char_id)
        {
            using (OfficePoll2Entities entities = new OfficePoll2Entities())
            {
                var answerToUpdate = entities.Answers_to_the_Characteristics.Find(id);
                answerToUpdate.text = text;
                answerToUpdate.characteristic_id = char_id;
                entities.SaveChanges();

            }
        }

        public void DeleteAnswerToCharacteristic(int id)
        {
            using (OfficePoll2Entities entities = new OfficePoll2Entities())
            {
                var answerToDelete = entities.Answers_to_the_Characteristics.Find(id);
                entities.Answers_to_the_Characteristics.Remove(answerToDelete);
                entities.SaveChanges();

            }
        }

        public Answers_to_the_Characteristics SelectAnswerToCharacteristic(int id)
        {
            using (OfficePoll2Entities entities = new OfficePoll2Entities())
            {
                return entities.Answers_to_the_Characteristics.Find(id);

            }
        }
    }
}
