using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PresenceLog_SportLib
{
    public class Trainingsgruppe
    {
        public List<string> Wochentage = new List<string>();
        public string Name { get; set; }
        public DateTime DatumErstesTraining {  get; set; }
        public DateTime DatumLetztesTraining { get; set; }
        public Person Mitglied { get; set; }

        public Trainingsgruppe(List<string> wochentage, string name, DateTime datumErstesTraining, DateTime datumLetztesTraining)
        {
            this.Wochentage = wochentage;
            this.Name = name;
            this.DatumErstesTraining = datumErstesTraining;
            this.DatumLetztesTraining = datumLetztesTraining;
        }

        public void MitgliederHinzufügen(Person mitglied)
        {

        }


    }
}
