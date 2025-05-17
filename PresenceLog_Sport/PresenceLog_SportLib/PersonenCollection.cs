
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PresenceLog_SportLib
{
    public class PersonenCollection
    {
        private List<Person> Personen = new List<Person>();

        public PersonenCollection()
        {

        }

        public PersonenCollection(List<Person> personen)
        {
            this.Personen = personen;
        }

        public void PersonHinzufügen(Person person)
        {
            Personen.Add(person);
        }


        public void Laden(string filename)
        {
            try
            {
                Personen.Clear();

                using (StreamReader stream = new StreamReader(filename))
                {
                    while (!stream.EndOfStream)
                    {
                        string personenString = stream.ReadLine();
                        if (!string.IsNullOrEmpty(personenString))
                        {
                            try
                            {
                                Personen.Add(Person.Deserialisieren(personenString));
                            }
                            catch (IOException exception)
                            {
                                {
                                    MessageBox.Show($"Fehler beim Deserialisieren einer Person: {exception.Message}");
                                }

                            }


                        }
                    }
                }
            }
            catch(IOException exception)
            {
                MessageBox.Show($"Fehler beim Laden der Datei: {exception.Message}");
            }
            
        }

        public void Speichern(string filename)
        {
            try
            {
                using (StreamWriter stream = new StreamWriter(filename))
                {
                    foreach (Person Person in Personen)
                    {
                        stream.WriteLine(Person.Serialisieren());
                    }
                }
            }
            catch(IOException exception)
            {
                MessageBox.Show($"Fehler beim Speichern der Datei: {exception.Message}");
            }
            
        }


    }

   


}
