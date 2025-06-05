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
        // TODO: Liste aller Trainingsgruppen!


        public TrainingsgruppeCollection<Trainingsgruppe> trainingsgruppeCollection = new TrainingsgruppeCollection();

        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void GruppeErstellenBtn_Click(object sender, RoutedEventArgs e)
        {
            TrainingsgruppeErstellen window = new TrainingsgruppeErstellen();
        
            if (window.ShowDialog() == true)
            {        

            }
        }

        private void DatePickerTraining_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO: Filtern der Trainingsgruppen

            DateTime date = DatePickerTraining.SelectedDate.Value;

            
            foreach (Trainingsgruppe gruppe in trainingsgruppeCollection.Trainingsgruppen)
            {
                if (gruppe.Wochentage.Contains(date.DayOfWeek.ToString()))
                {

                }
            }
        }
    }
}