using PresenceLog_SportLib;
using Serilog;
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
           
            if (DatePickerStartdatum == null)
            {
                Log.Logger.Error("'DatePickerStartdatum' ist leer");
                MessageBox.Show("Bitte wählen Sie ein Startdatum für diese Gruppe aus");
                return;
            }

            if (DatePickerEnddatum == null)
            {
                Log.Logger.Error("'DatePickerEnddatum' ist leer");
                MessageBox.Show("Bitte wählen Sie ein Enddatum für diese Gruppe aus");
                return;
            }

            Anfangsdatum = DatePickerStartdatum.SelectedDate.Value;
            Enddatum = DatePickerEnddatum.SelectedDate.Value;

            bool einwochentagauswaehlen =
                CheckBoxMontag.IsChecked == true || CheckBoxDienstag.IsChecked == true ||
                CheckBoxMittwoch.IsChecked == true || CheckBoxDonnerstag.IsChecked == true ||
                CheckBoxFreitag.IsChecked == true || CheckBoxSamstag.IsChecked == true ||
                CheckBoxSonntag.IsChecked == true;

            if (!einwochentagauswaehlen)
            {
                Log.Logger.Error("Es ist kein Wochentag ausgewählt");
                MessageBox.Show("Bitte wählen Sie mindestens ein Wochentag aus!");
            }


            Titel = TextBoxTitel.Text;
            AusgewaehlteTage = checkedDays();
            Anfangsdatum = DatePickerStartdatum.SelectedDate.Value;
            Enddatum = DatePickerEnddatum.SelectedDate.Value;

            foreach(var Item in ListViewMitglieder.Items)
            {
                if(Item is Person person && person.IstInTrainingsgruppe == true)
                {
                    AusgewaehltePersonen.PersonHinzufügen(person);
                }
            }


            this.DialogResult = true; // Fenster mit "OK" schließen
            this.Close();
            Log.Logger.Information("Trainingsgruppe-erstellen-Fenster wurde durch OK-Button geschlossen");
        }

        private void AbbrechenBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close(); /* Schließt das Fenster, sobald man auf den Abbrechen Button drückt*/
            Log.Logger.Information("Trainingsgruppe-erstellen-Fenster wurde durch Abbrechen-Button geschlossen");
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
                Personen.PersonHinzufügen(person);
                Personen.Speichern("data/gespeichertePersonen.txt");
            }
        }

        private void TextBoxTitel_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxTitel.Text))
            {
                TextBoxTitel.Background = Brushes.Red;
                Log.Logger.Error("TextBoxTitel ist leer");
            }
            else
            {
                TextBoxTitel.Background = Brushes.White;
            }
        }
    }
}
