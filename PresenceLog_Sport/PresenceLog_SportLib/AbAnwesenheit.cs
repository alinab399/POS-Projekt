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

        private string begruending;
        public string Begruendung { get => begruending; 
            set { 
                begruending = value;
                OnPropertyChanged(nameof(Begruendung));
            } }

        public AbAnwesenheit() { }
        public AbAnwesenheit(bool status)
        {
            this.Status = status;
        }
        public AbAnwesenheit(bool status, string begruendung)
        {
            this.Status = status;
            this.Begruendung = begruendung;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Serialisieren()
        {
            string statusString = Status.ToString();

            return $"{statusString}§{Begruendung}"; // Ein Trennzeichen das warscheinlich nicht in der Begründung vorkommt
        }

        
        public static AbAnwesenheit Deserialisieren(string serialized)
        {
            string[] DataSplit = serialized.Split('§');

            bool status = bool.Parse(DataSplit[0]);
            string begruendung = DataSplit[1];

            return new AbAnwesenheit(status, begruendung);
        }

        protected void OnPropertyChanged(string property)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

    }
}
