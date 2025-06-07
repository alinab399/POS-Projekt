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

        private PersonenCollection personen;
        public PersonenCollection Personen 
        { 
            get => personen; 
            set 
            { 
                personen = value;

                ListViewMitglieder.ItemsSource = personen.Personen;
                ListViewMitglieder.UpdateLayout();
            } 
        }
        public PersonenCollection AusgewaehltePersonen = new PersonenCollection();




        

        public TrainingsgruppeErstellen()
        {
            InitializeComponent();

            DatePickerStartdatum.SelectedDate = DateTime.Now;
            DatePickerEnddatum.SelectedDate = DateTime.Now.AddDays(7);
            
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            Titel = TextBoxTitel.Text;
            AusgewaehlteTage = checkedDays();
            Anfangsdatum = DatePickerStartdatum.SelectedDate.Value;
            Enddatum = DatePickerEnddatum.SelectedDate.Value;

            foreach(Person Mitglied in ListViewMitglieder.Items)
            {
                if(Mitglied.IstInTrainingsgruppe == true)
                {
                    AusgewaehltePersonen.PersonHinzufügen(Mitglied);
                }
            }


            this.DialogResult = true; // Fenster mit "OK" schließen
            this.Close();
        }

        private void AbbrechenBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
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

        private void HinzufuegenBtn_Click(object sender, RoutedEventArgs e)
        {
            Personhinzufuegen neueperson = new Personhinzufuegen();
            if (neueperson.ShowDialog() == true)
            {
                Person person = new Person();
                person.Vorname = neueperson.Vorname;
                person.Nachname = neueperson.Nachname;
                person.Geburtsdatum = neueperson.Geburtsdatum;
            }
           
        }
    }
}
