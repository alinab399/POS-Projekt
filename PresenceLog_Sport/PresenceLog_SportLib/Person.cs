
using System.Xml.Linq;

namespace PresenceLog_SportLib
{
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public AbAnwesenheit Anwesenheit { get; set; }

        public Person(string vorname, string nachname, DateTime geburtsdatum)
        {
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Geburtsdatum = geburtsdatum;
        }

        public Person(string vorname, string nachname, DateTime geburtsdatum, AbAnwesenheit anwesenheit)
        {
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Geburtsdatum = geburtsdatum;
            this.Anwesenheit = anwesenheit;
        }


        public string AnwesenheitSerialisieren()
        {
            string anwesenheitString = "";

            for (int i = 0; i < Anwesenheit.Count; i++)
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
            string geburtsdatumString = Geburtsdatum.ToString("yyyy-MM-dd");

            return $"{Vorname};{Nachname};{geburtsdatumString};{anwesenheitString}";
        }

        public static Person Deserialisieren(string serialized)
        {
            string[] DataSplit = serialized.Split(";");

            string vorname = DataSplit[0];
            string nachname = DataSplit[1];
            DateTime geburtsdatum = DateTime.Parse(DataSplit[2]);
            

            string anwesenheitString = DataSplit[3];
            AbAnwesenheit abAnwesenheit = new AbAnwesenheit();
            abAnwesenheit = AbAnwesenheit.Deserialisieren(anwesenheitString);
            
            
            

            return new Person(vorname, nachname, geburtsdatum, abAnwesenheit);
        }

       
    }

}
