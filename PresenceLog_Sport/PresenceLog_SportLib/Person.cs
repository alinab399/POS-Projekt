
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


        public void Answesenheit_Speichern(List<bool> answesend)
        {

        }

        public void Answesenheit_Laden(List<bool> answesend)
        {

        }

        public string Serialize()
        {
            return $"{Vorname};{Nachname};{Geburtstag};{Anwesend}";
        }

        public static Person Deserialize(string serialized)
        {
            string[] DataSplit = serialized.Split(";");

            string vorname = DataSplit[0];
            string nachname = DataSplit[1];
            DateTime geburtstag = DateTime.Parse(DataSplit[2]);
            List<bool> anwesend = ParseAnwesenheitListe(DataSplit[3]);

            return new Person(vorname, nachname, geburtstag);
        }

        public static List<bool> ParseAnwesenheitListe(string anwesenheitString)
        {
            // TODO: Deserialisieren der AnwesenheitsListe
            return null;
        }
       
    }

}
