
using System.ComponentModel;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace PresenceLog_SportLib
{
    public class Person : INotifyPropertyChanged
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        private DateTime geburtsdatum;
        public DateTime Geburtsdatum 
        {
            get
            {
                return geburtsdatum.Date;
            }
            set{
                geburtsdatum = value.Date;
            } 
        }
        public List<AbAnwesenheit> Anwesenheiten {  get; set; } = new List<AbAnwesenheit>();

        private AbAnwesenheit anwesenheit = new AbAnwesenheit();
        public AbAnwesenheit Anwesenheit { get => anwesenheit; set
            {
                anwesenheit = value;
                OnPropertyChanged(nameof(Anwesenheit));
            } 
        }

        public bool IstInTrainingsgruppe { get; set; }= false;

        public Person()
        {

        }

        public Person(string vorname, string nachname, DateTime geburtsdatum)
        {
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Geburtsdatum = geburtsdatum;
        }
        public Person(string vorname, string nachname,bool istInTrainingsgruppe, DateTime geburtsdatum, AbAnwesenheit anwesenheit)
        {
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.IstInTrainingsgruppe = istInTrainingsgruppe;
            this.Geburtsdatum = geburtsdatum;
            this.Anwesenheit = anwesenheit;
        }

        public Person(string vorname, string nachname, DateTime geburtsdatum, AbAnwesenheit anwesenheit)
        {
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.Geburtsdatum = geburtsdatum;
            this.Anwesenheit = anwesenheit;
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        public string Serialisieren()
        {
            string geburtsdatumString = Geburtsdatum.ToString("yyyy-MM-dd");

            string anwesenheitenJson = JsonConvert.SerializeObject(Anwesenheiten);

            return $"{Vorname};{Nachname};{geburtsdatumString};{anwesenheitenJson}";
        }

        public static Person Deserialisieren(string serialized)
        {
            string[] DataSplit = serialized.Split(";", 4); // In 4 Teile trennen: Vorname;Nachname;Geburtsdatum;Anwesenheiten

            string vorname = DataSplit[0];
            string nachname = DataSplit[1];
            DateTime geburtsdatum = DateTime.Parse(DataSplit[2]);

            List<AbAnwesenheit> anwesenheiten;

            try
            {
                anwesenheiten = JsonConvert.DeserializeObject<List<AbAnwesenheit>>(DataSplit[3]);
            }
            catch (JsonReaderException)
            {
                // Falls kein gültiges JSON ? leere Liste verwenden
                anwesenheiten = new List<AbAnwesenheit>();
            }

            // Neues Person-Objekt mit deserialisierten Werten erzeugen
            Person person = new Person(vorname, nachname, geburtsdatum)
            {
                Anwesenheiten = anwesenheiten
            };

            return person;
        }




        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        
       
    }

}
