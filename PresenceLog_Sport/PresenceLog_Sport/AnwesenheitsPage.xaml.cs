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
        public DateTime AusgewaehltesDatum { get; set; }
        public PersonenCollection personenCollection { get; set; } = new PersonenCollection();
        public Trainingsgruppe TrainingsgruppeAktuell { get; set; } = new Trainingsgruppe();
        public AnwesenheitsPage(Trainingsgruppe trainingsgruppe, DateTime datum)
        {
            InitializeComponent();

            this.TrainingsgruppeAktuell = trainingsgruppe;
            this.personenCollection = trainingsgruppe.Mitglieder;
            this.AusgewaehltesDatum = datum;
          

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
            person.Anwesenheiten.Add(new AbAnwesenheit(true, "War anwesend", AusgewaehltesDatum));

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
                person.Anwesenheiten.Add(new AbAnwesenheit(false, abwesendBegruendungWindow.Begruendung, AusgewaehltesDatum));
            }
            else
            {
                person.Anwesenheiten.Add(new AbAnwesenheit(false, "War abwesend", AusgewaehltesDatum));
            }

            CollectionViewSource.GetDefaultView(ListViewAnwesenheit.ItemsSource).Refresh();
        }

        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService != null && this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        private void ButtonAnalyse_Click(object sender, RoutedEventArgs e)
        {
            AnalysePage analysieren = new AnalysePage(TrainingsgruppeAktuell);
            this.NavigationService.Navigate(analysieren);
        }

        private void AnwesendButton_Loaded(object sender, RoutedEventArgs e)
        {
            Button loadedButton = (Button)sender;
            StackPanel stackPanel = (StackPanel)loadedButton.Parent;
            Person person = (Person)stackPanel.DataContext;

            foreach (AbAnwesenheit eintrag in person.Anwesenheiten)
            {
                if (eintrag.Datum == AusgewaehltesDatum)
                {
                    loadedButton.Background = Brushes.ForestGreen;
                }
            }
            
        }

        private void AbwesendButton_Loaded(object sender, RoutedEventArgs e)
        {
            Button loadedButton = (Button)sender;
            StackPanel stackPanel = (StackPanel)loadedButton.Parent;
            Person person = (Person)stackPanel.DataContext;

            foreach (AbAnwesenheit eintrag in person.Anwesenheiten)
            {
                if (eintrag.Datum == AusgewaehltesDatum)
                {
                    loadedButton.Background = Brushes.IndianRed;
                }
            }
        }
    }
}
