using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresenceLog_SportLib
{
    public class TrainingsgruppeCollection
    {
        public List<Trainingsgruppe> Trainingsgruppen = new List<Trainingsgruppe>();

        public TrainingsgruppeCollection()
        {

        }

        public TrainingsgruppeCollection(List<Trainingsgruppe> trainingsgruppen)
        {

        }
        
        public void TrainingsgruppenHinzufuegen(Trainingsgruppe trainingsgruppe)
        {
            Trainingsgruppen.Add(trainingsgruppe);
        }

    }
}

