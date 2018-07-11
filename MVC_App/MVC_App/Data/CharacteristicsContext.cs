using MVC_App.Models.Administrator;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_App.Data
{
    public class CharacteristicsContext
    {
        public void CreateCharacteristic(String txt)
        {
            using (OfficePoll2Entities entities = new OfficePoll2Entities())
            {
                entities.Characteristics.Add(new Characteristics() { text = txt });
                entities.SaveChanges();

            }
        }

        public void UpdateCharacteristic(int id, String text)
        {
            using (OfficePoll2Entities entities = new OfficePoll2Entities())
            {
                var characteristicToUpdate = entities.Characteristics.Find(id);
                characteristicToUpdate.text = text;
                entities.SaveChanges();

            }
        }

        public void DeleteCharacteristic(int id)
        {
            using (OfficePoll2Entities entities = new OfficePoll2Entities())
            {

                var characteristicToDelete = entities.Characteristics.Find(id);
                entities.Characteristics.Remove(characteristicToDelete);
                entities.SaveChanges();

            }
        }

        public Characteristics SelectCharacteristic(int id)
        {
            using (OfficePoll2Entities entities = new OfficePoll2Entities())
            {
                return entities.Characteristics.Find(id);

            }
        }

        public CharacteristicModel GetAllCharacteristicAnswers()
        {
            CharacteristicModel result = new CharacteristicModel(); 
            try
            {
                using (OfficePoll2Entities entities = new OfficePoll2Entities())
                {   
                    var characteristic = entities.Characteristics.FirstOrDefault();
                    result._text = characteristic.text;
                    result.id = characteristic.id;

                    var answers = entities.Answers_to_the_Characteristics.Where(q => q.characteristic_id == characteristic.id);
                    foreach (var item in answers)
                    {
                        result.answers_to_characteristic.Add(new AnswerToCharacteristicModel() { Text = item.text , CharacteristicId = characteristic.id });
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public List<CharacteristicModel> GetListOfAllCharacteristicsWithTheyAnswers()
        {
            List<CharacteristicModel> result = new List<CharacteristicModel>();
            try
            {
                using (OfficePoll2Entities entities = new OfficePoll2Entities())
                {
                    foreach (var characteristic_ in entities.Characteristics)
                    {
                        CharacteristicModel temp = new CharacteristicModel();

                        temp._text = characteristic_.text;
                        temp.id = characteristic_.id;

                        var answers = entities.Answers_to_the_Characteristics.Where(q => q.characteristic_id == characteristic_.id);
                        foreach (var item in answers)
                        {
                            temp.answers_to_characteristic.Add(new AnswerToCharacteristicModel() { Text = item.text, CharacteristicId = characteristic_.id });
                        }
                        result.Add(temp);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

    }
}