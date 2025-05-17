
using System.Xml.Linq;

namespace PresenceLog_SportLib
{
    public class Person
    {
        private string Vorname { get; set; }
        private string Nachname { get; set; }
        private DateTime Geburtstag;
        private List<bool> Anwesend = new List<bool>();

        public Person(string vorname, string nachname, DateTime geburtstag)
        {
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Geburtstag = geburtstag;
        }

        public Person(string vorname, string nachname, DateTime geburtstag, List<bool> anwesend)
        {
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Geburtstag = geburtstag;
            this.Anwesend = anwesend;
        }


        public string AnwesenheitSerialisieren()
        {
            string anwesenheitString = "";

            for (int i = 0; i < Anwesend.Count; i++)
            {
                anwesenheitString += Anwesend[i].ToString();

                if (i < Anwesend.Count - 1)
                {
                    anwesenheitString += ",";
                }
            }

            return anwesenheitString;

        }

        public static List<bool> AnwesenheitDeserialisieren(string anwesenheitString)
        {
            List<bool> anwesend = new List<bool>();

            string[] teile = anwesenheitString.Split(',');

            foreach (string teil in teile)
            {
                anwesend.Add(bool.Parse(teil));
            }

            return anwesend;
        }

        public string Serialisieren()
        {
            string anwesenheitString = AnwesenheitSerialisieren();
            string geburtstagString = Geburtstag.ToString("yyyy-MM-dd");

            return $"{Vorname};{Nachname};{geburtstagString};{anwesenheitString}";
        }

        public static Person Deserialisieren(string serialized)
        {
            string[] DataSplit = serialized.Split(";");

            string vorname = DataSplit[0];
            string nachname = DataSplit[1];
            DateTime geburtstag = DateTime.Parse(DataSplit[2]);
            

            string anwesenheitString = DataSplit[3];
            List<bool> anwesend = AnwesenheitDeserialisieren(anwesenheitString);

            return new Person(vorname, nachname, geburtstag, anwesend);
        }

       
    }

}
