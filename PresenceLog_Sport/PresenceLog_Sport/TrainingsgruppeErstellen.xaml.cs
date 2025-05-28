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
using System.Windows.Shapes;

namespace PresenceLog_Sport
{
    /// <summary>
    /// Interaction logic for TrainingsgruppeErstellen.xaml
    /// </summary>
    public partial class TrainingsgruppeErstellen : Window
    {
        List<string> wochentage = new List<string>(){
            "montag", "dienstag", "mittwoch", "donnerstag", "freitag", "samstag", "sonntag"
    };
        public TrainingsgruppeErstellen()
        {
            InitializeComponent();
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true; /* Wenn man auf OK drückt, dann schließ sich das Fenster, da
                                       * man das DialogResult auf True gesetzt hat*/
            string titel = TextBoxTitel.Text;
            DateTime enddatum = Enddate.SelectedDate ?? DateTime.Today;
            DateTime anfangsdatum = Startdate.SelectedDate ?? DateTime.Today;
            Trainingsgruppe trainingsgruppe = new Trainingsgruppe(wochentage,titel,enddatum, anfangsdatum);
        }

        private void AbbrechenBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); /* Schließt das Fenster, sobald man auf den Abbrechen Button drückt*/
        }

       
    }
}
