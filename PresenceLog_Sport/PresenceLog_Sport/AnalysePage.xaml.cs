using PresenceLog_SportLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresenceLog_Sport
{
    /// <summary>
    /// Interaction logic for AnalysePage.xaml
    /// </summary>
    public partial class AnalysePage : Page
    {
        public PersonenCollection PersonenColl { get; set; }
        
        public AbAnwesenheit Anwesenheit { get; set; } = new AbAnwesenheit();

        public AnalysePage(Trainingsgruppe trainingsgruppe)
        {
            InitializeComponent();
            this.PersonenColl = trainingsgruppe.Mitglieder;
            ListViewAnalyse.ItemsSource = GeneriereAnalyseEinträge();
        }

        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService != null && this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        private List<AnalyseEintrag> GeneriereAnalyseEinträge()
        {
            List<AnalyseEintrag> analyseEintraege = new List<AnalyseEintrag>();
            foreach (Person person in PersonenColl.Personen)
            {
                int anwesend = 0;
                foreach (AbAnwesenheit eintrag in person.Anwesenheiten)
                {
                    if (eintrag.Status == true)
                    {
                        anwesend++;
                    }
                }
                int gesamt = person.Anwesenheiten.Count;

                analyseEintraege.Add(new AnalyseEintrag(person.Vorname, person.Nachname, anwesend, gesamt));
            }

            return analyseEintraege;
        }
    }
}
