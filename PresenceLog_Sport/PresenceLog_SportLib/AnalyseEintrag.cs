using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresenceLog_SportLib
{
    public class AnalyseEintrag
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int AnzahlAnwesenheiten { get; set; }
        public int GesamtTrainings { get; set; }

        public string Anzeige 
        {
            get {
                return $"{AnzahlAnwesenheiten} / {GesamtTrainings}";
            }
        }

        public AnalyseEintrag(string vorname, string nachname, int anzahlAnwesenheiten, int gesamtTrainings)
        {
            this.Vorname = vorname;
            this.Nachname = nachname;
            this.AnzahlAnwesenheiten = anzahlAnwesenheiten;
            this.GesamtTrainings = gesamtTrainings;
        }

    }
}
