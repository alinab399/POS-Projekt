using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresenceLog_SportLib
{
    public class AbAnwesenheit
    {
        public bool Status { get; set; }
        public string Begruendung { get; set; }

        public AbAnwesenheit() { }
        public AbAnwesenheit(bool status, string begruendung)
        {
            this.Status = status;
            this.Begruendung = begruendung;
        }
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

    }
}
