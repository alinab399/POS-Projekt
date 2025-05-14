
namespace PresenceLog_SportLib
{
    public class Person
    {
        private string Vorname { get; set; }
        private string Nachname { get; set; }
        private DateTime Geburtstag;
        private List<bool> Answesend = new List<bool>();

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
    }

}
