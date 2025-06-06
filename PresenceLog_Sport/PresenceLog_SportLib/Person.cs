
using System.ComponentModel;
using System.Xml.Linq;

namespace PresenceLog_SportLib
{
    public class Person : INotifyPropertyChanged
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime Geburtsdatum { get; set; }

        private AbAnwesenheit anwesenheit = new AbAnwesenheit(false, "");
        public AbAnwesenheit Anwesenheit { get => anwesenheit; set
            {
                anwesenheit = value;
                OnPropertyChanged(nameof(Anwesenheit));
            } 
        }

        public bool IstInTrainingsgruppe { get; set; }

       

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

        public Person()
        {
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Serialisieren()
        {
            string anwesenheitString = Anwesenheit.Serialisieren();
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

        protected void OnPropertyChanged(string property)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
       
    }

}
