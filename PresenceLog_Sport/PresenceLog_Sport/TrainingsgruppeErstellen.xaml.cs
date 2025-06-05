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
        public string Titel {  get; set; }
        public List<string> AusgewaehlteTage {  get; set; }
        public DateTime Anfangsdatum {  get; set; }
        public DateTime Enddatum {  get; set; }
        public PersonenCollection Personen { get; set; }

        public TrainingsgruppeErstellen()
        {
            InitializeComponent();
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            Titel = TextBoxTitel.Text;
            AusgewaehlteTage = checkedDays();
            Anfangsdatum = DatePickerStartdatum.SelectedDate.Value;
            Enddatum = DatePickerEnddatum.SelectedDate.Value;

            // TODO: Listview mit Checkboxen
            
            this.DialogResult = true; // Fenster mit "OK" schließen
            this.Close();
        }

        private void AbbrechenBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); /* Schließt das Fenster, sobald man auf den Abbrechen Button drückt*/
        }

        private List<string> checkedDays()
        {
            List <string> days = new List<string>();
            if (CheckBoxMontag.IsChecked == true)
            {
                days.Add("Monday");
            }
            if (CheckBoxDienstag.IsChecked == true)
            {
                days.Add("Tuesday");
            }
            if (CheckBoxMittwoch.IsChecked == true)
            {
                days.Add("Wednesday");
            }
            if (CheckBoxDonnerstag.IsChecked == true)
            {
                days.Add("Thursday");
            }
            if (CheckBoxFreitag.IsChecked == true)
            {
                days.Add("Friday");
            }
            if (CheckBoxSamstag.IsChecked == true)
            {
                days.Add("Saturday");
            }
            if (CheckBoxSonntag.IsChecked == true)
            {
                days.Add("Sunday");
            }
            return days;
        }

       
    }
}
