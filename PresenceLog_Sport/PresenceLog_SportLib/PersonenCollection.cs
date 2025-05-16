
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresenceLog_SportLib
{
    public class PersonenCollection
    {
        public List<Person> Personen = new List<Person>();

        public PersonenCollection()
        {

        }

        public PersonenCollection(List<Person> personen)
        {

        }

        public void PersonenHinzufügen(Person person)
        {

        }


        public void LoadFromCSV(string filename)
        {
            Personen.Clear();

            using (StreamReader stream = new StreamReader(filename))
            {
                while (!stream.EndOfStream)
                {
                    string personenString = stream.ReadLine();

                    Personen.Add(Person.Deserialize(personenString));
                }
            }
        }


    }

   


}
