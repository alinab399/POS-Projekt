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
        public string TrainingsTitel { get; set; }
        public TrainingsgruppeErstellen()
        {
            InitializeComponent();
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            TrainingsTitel = TextBoxTitel.Text;  // Titel speichern
            this.DialogResult = true; // Fenster mit "OK" schließen
            this.Close();
        }

        private void AbbrechenBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); /* Schließt das Fenster, sobald man auf den Abbrechen Button drückt*/
        }

       
    }
}
