using PresenceLog_SportLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for AnwesenheitsPage.xaml
    /// </summary>
    public partial class AnwesenheitsPage : Page
    {
        public PersonenCollection personenCollection = new PersonenCollection();
        public Trainingsgruppe Traingsgruppe = new Trainingsgruppe();
        public AnwesenheitsPage(Trainingsgruppe trainingsgruppe)
        {
            InitializeComponent();

            this.Traingsgruppe = trainingsgruppe;
            this.personenCollection = trainingsgruppe.Mitglieder;
          

            ListViewAnwesenheit.ItemsSource = personenCollection.Personen;

        }
        private void AnwesendButton_Click(object sender, RoutedEventArgs e)
        {

            Button clickedButton = (Button)sender;
            StackPanel stackPanel = (StackPanel)clickedButton.Parent; // Wenn die Umwandlung nicht möglich ist, wird eine InvalidCastException geworfen

            foreach (Button button in stackPanel.Children)
            {
                button.Background = Brushes.LightGray;
            }

            clickedButton.Background = Brushes.ForestGreen;

            Person person = (Person)stackPanel.DataContext;
            person.Anwesenheit = new AbAnwesenheit(true);

        }

        private void AbwesendButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            StackPanel stackPanel = (StackPanel)clickedButton.Parent; // Wenn die Umwandlung nicht möglich ist, wird eine InvalidCastException geworfen

            foreach (Button button in stackPanel.Children)
            {
                button.Background = Brushes.LightGray;
            }

            clickedButton.Background = Brushes.IndianRed;

            Person person = (Person)stackPanel.DataContext;

            AbwesendBegruendung abwesendBegruendungWindow = new AbwesendBegruendung();
            if (abwesendBegruendungWindow.ShowDialog() == true)
            {
                
            }
            person.Anwesenheit.Begruendung = abwesendBegruendungWindow.TextBoxBegruendung.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { /* Home Button */
            MainWindow erstesfenster = new MainWindow();
            erstesfenster.ShowDialog();
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { /* Analyse Button */
            AnalysePage analysieren = new AnalysePage();
            this.NavigationService.Navigate(analysieren);
            
           
        }
    }
}
