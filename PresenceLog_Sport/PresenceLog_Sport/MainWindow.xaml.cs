using PresenceLog_SportLib;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TrainingsgruppeCollection trainingsgruppeCollection = new TrainingsgruppeCollection();

        public MainWindow()
        {
            InitializeComponent();
            trainingsgruppeCollection.Laden("data/gespeicherteTrainingsgruppen.json");
            /*List<string> days = new List<string>();
            days.Add("Monday");
            days.Add("Tuesday");


            Trainingsgruppe trainingsgruppetest = new Trainingsgruppe(days, "Test", DateTime.Now, DateTime.Now);
            trainingsgruppeCollection.TrainingsgruppenHinzufuegen(trainingsgruppetest);*/

        }

        private void GruppeErstellenBtn_Click(object sender, RoutedEventArgs e)
        {

            TrainingsgruppeErstellen window = new TrainingsgruppeErstellen();
            Trainingsgruppe trainingsgruppe = new Trainingsgruppe();
            PersonenCollection personenListe = new PersonenCollection();

            personenListe.Laden("data/gespeichertePersonen.txt");
            window.Personen = personenListe;

            if (window.ShowDialog() == true)
            {
                trainingsgruppe.Name = window.Titel;
                trainingsgruppe.Wochentage = window.AusgewaehlteTage;
                trainingsgruppe.DatumErstesTraining = window.Anfangsdatum;
                trainingsgruppe.DatumLetztesTraining = window.Enddatum;
                trainingsgruppe.Mitglieder = window.AusgewaehltePersonen;
            }

            trainingsgruppeCollection.TrainingsgruppenHinzufuegen(trainingsgruppe);
            trainingsgruppeCollection.Speichern("data/gespeicherteTrainingsgruppen.json");
        }

        private void DatePickerTraining_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            WrapPannelTrainingsgruppen.Children.Clear();
            // TODO: Filtern der Trainingsgruppen
            trainingsgruppeCollection.Laden("data/gespeicherteTrainingsgruppen.json");

            DateTime date = DatePickerTraining.SelectedDate.Value;

            
            foreach (Trainingsgruppe gruppe in trainingsgruppeCollection.Trainingsgruppen)
            {
                System.Diagnostics.Debug.WriteLine($"Gruppe: {gruppe.Name}");
                System.Diagnostics.Debug.WriteLine($"Von: {gruppe.DatumErstesTraining.ToShortDateString()} Bis: {gruppe.DatumLetztesTraining.ToShortDateString()}");
                if (gruppe.Wochentage == null)
                {
                    System.Diagnostics.Debug.WriteLine("Wochentage ist NULL!");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Wochentage: " + string.Join(", ", gruppe.Wochentage));
                }
                if (gruppe.DatumErstesTraining <= date && 
                    gruppe.DatumLetztesTraining >= date && 
                    gruppe.Wochentage.Contains(date.DayOfWeek.ToString()))
                {
                    TrainingsgruppeUserControl trainingsgruppeUserControl = new TrainingsgruppeUserControl(gruppe.Name);
                    WrapPannelTrainingsgruppen.Children.Add(trainingsgruppeUserControl);
                }
            }




            if (WrapPannelTrainingsgruppen.Children.Count == 0)
            {
                MessageBox.Show("Keine Trainingsgruppen für den ausgewählten Tag gefunden.");
            }
        }
    }
}