using PresenceLog_SportLib;
using Serilog;
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
            Log.Logger.Information("Alle Button auf Grau gesetzt");

            clickedButton.Background = Brushes.ForestGreen;
            Log.Logger.Information("Anwesend-Button auf Grün gesetzt");

            Person person = (Person)stackPanel.DataContext;

            AbAnwesenheit vorhandenerEintrag = null;
            foreach (AbAnwesenheit eintrag in person.Anwesenheiten)
            {
                if (eintrag.Datum.Date == AusgewaehltesDatum.Date)
                {
                    vorhandenerEintrag = eintrag;
                    break;
                }
            }

            if (vorhandenerEintrag != null)
            {
                vorhandenerEintrag.Status = true;
                vorhandenerEintrag.Begruendung = "War anwesend";
            }
            else
            {
                person.Anwesenheiten.Add(new AbAnwesenheit(true, "War anwesend", AusgewaehltesDatum));
            }

        }

        private void AbwesendButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            StackPanel stackPanel = (StackPanel)clickedButton.Parent; // Wenn die Umwandlung nicht möglich ist, wird eine InvalidCastException geworfen

            foreach (Button button in stackPanel.Children)
            {
                button.Background = Brushes.LightGray;
            }
            Log.Logger.Information("Alle Button auf Grau gesetzt");

            clickedButton.Background = Brushes.IndianRed;
            Log.Logger.Information("Anwesend-Button auf Grün gesetzt");

            Person person = (Person)stackPanel.DataContext;

            AbAnwesenheit vorhandenerEintrag = null;
            foreach (AbAnwesenheit eintrag in person.Anwesenheiten)
            {
                if (eintrag.Datum.Date == AusgewaehltesDatum.Date)
                {
                    vorhandenerEintrag = eintrag;
                    break;
                }
            }

            AbwesendBegruendung abwesendBegruendungWindow = new AbwesendBegruendung();
            if (abwesendBegruendungWindow.ShowDialog() == true)
            {
                if (vorhandenerEintrag != null)
                {
                    vorhandenerEintrag.Status = false;
                    vorhandenerEintrag.Begruendung = abwesendBegruendungWindow.Begruendung;
                }
                else
                {
                    person.Anwesenheiten.Add(new AbAnwesenheit(false, abwesendBegruendungWindow.Begruendung, AusgewaehltesDatum));
                }

                Log.Logger.Information("Begründung eingegeben und gespeichert");
            }
            else
            {
                if (vorhandenerEintrag != null)
                {
                    vorhandenerEintrag.Status = false;
                    vorhandenerEintrag.Begruendung = "War abwesend";
                }
                else
                {
                    person.Anwesenheiten.Add(new AbAnwesenheit(false, "War abwesend", AusgewaehltesDatum));
                }

                Log.Logger.Information("Keine Begründung eingegeben und stattdessen 'War abwesend' gespeichert");
            }

            // Aktualisieren aller Felder
            CollectionViewSource.GetDefaultView(ListViewAnwesenheit.ItemsSource).Refresh();
            Log.Logger.Information("ListViewAnwesenheit upgedatet");
        }

        private void ButtonZurueck_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService != null && this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
                Log.Logger.Information("Von AnwesenheitsPage zu vorheriger Seite (StartPage) gewechselt");
            }
        }

        private void ButtonAnalyse_Click(object sender, RoutedEventArgs e)
        {
            AnalysePage analysieren = new AnalysePage(TrainingsgruppeAktuell);
            this.NavigationService.Navigate(analysieren);
            Log.Logger.Information("Zu AnalysePage gewechselt");
        }

        private void AnwesendButton_Loaded(object sender, RoutedEventArgs e)
        {
            Log.Debug("AnwesendButton wurde geladen");
            Button loadedButton = (Button)sender;
            StackPanel stackPanel = (StackPanel)loadedButton.Parent;
            Person person = (Person)stackPanel.DataContext;

            foreach (AbAnwesenheit eintrag in person.Anwesenheiten)
            {
                if (eintrag.Datum == AusgewaehltesDatum && eintrag.Status == true)
                {
                    loadedButton.Background = Brushes.ForestGreen;
                    Log.Debug("AbwesendButton wurde auf die Farbe Grün gesetzt");
                }
            }
            
        }

        private void AbwesendButton_Loaded(object sender, RoutedEventArgs e)
        {
            Log.Debug("AbwesendButton wurde geladen");
            Button loadedButton = (Button)sender;
            StackPanel stackPanel = (StackPanel)loadedButton.Parent;
            Person person = (Person)stackPanel.DataContext;

            foreach (AbAnwesenheit eintrag in person.Anwesenheiten)
            {
                if (eintrag.Datum == AusgewaehltesDatum && eintrag.Status == false)
                {
                    loadedButton.Background = Brushes.IndianRed;
                    Log.Debug("AbwesendButton wurde auf die Farbe Rot gesetzt");
                }
            }
        }

        private void TextBlockAbwesenheitBegruendung_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock = (TextBlock)sender;
            Person person = (Person)textBlock.DataContext;

            foreach (AbAnwesenheit eintrag in person.Anwesenheiten)
            {
                if (eintrag.Datum == AusgewaehltesDatum)
                {
                    textBlock.Text = eintrag.Begruendung;
                }
            }
        }
    }
}
