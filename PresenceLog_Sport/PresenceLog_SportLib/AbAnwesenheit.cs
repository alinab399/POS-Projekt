using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresenceLog_SportLib
{
    public class AbAnwesenheit : INotifyPropertyChanged
    {
        public bool Status { get; set; }

        private string begruendung;
        public string Begruendung { get => begruendung; 
            set { 
                begruendung = value;
                OnPropertyChanged(nameof(Begruendung));
            } }
        private DateTime datum;
        public DateTime Datum 
        { 
            get
            {
                return datum;
            }
            set { 
                datum = value;
                OnPropertyChanged(nameof(Datum));
            } 
        } 

        public AbAnwesenheit() { }
        public AbAnwesenheit(bool status, string begruendung, DateTime datum)
        {
            this.Status = status;
            this.Begruendung = begruendung;
            this.Datum = datum;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Serialisieren()
        {
            string statusString = Status.ToString();

            return $"{statusString}§{Begruendung}§{Datum:yyyy-MM-dd}"; // Ein Trennzeichen das warscheinlich nicht in der Begründung vorkommt
        }

        
        public static AbAnwesenheit Deserialisieren(string serialized)
        {
            string[] DataSplit = serialized.Split('§');

            bool status = bool.Parse(DataSplit[0]);
            string begruendung = DataSplit[1];
            DateTime datum = DateTime.Parse(DataSplit[2]);

            return new AbAnwesenheit(status, begruendung, datum);
        }

        protected void OnPropertyChanged(string property)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

    }
}
