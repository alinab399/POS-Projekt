﻿using PresenceLog_SportLib;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresenceLog_Sport
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public TrainingsgruppeCollection trainingsgruppeCollection = new TrainingsgruppeCollection();
        public StartPage()
        {
            InitializeComponent();
            trainingsgruppeCollection.Laden("data/gespeicherteTrainingsgruppen.json");
            
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
                trainingsgruppeCollection.TrainingsgruppenHinzufuegen(trainingsgruppe);
                Log.Logger.Information("Neue Trainingsgruppe wurde der TrainingsgruppeCollection hinzugefügt");
            }

            trainingsgruppeCollection.Speichern("data/gespeicherteTrainingsgruppen.json");
        }

        private void DatePickerTraining_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            WrapPannelTrainingsgruppen.Children.Clear();
            trainingsgruppeCollection.Laden("data/gespeicherteTrainingsgruppen.json");

            DateTime ausgewaehltesDatum = DatePickerTraining.SelectedDate.Value;


            foreach (Trainingsgruppe gruppe in trainingsgruppeCollection.Trainingsgruppen)
            {
                if (gruppe.DatumErstesTraining <= ausgewaehltesDatum &&
                    gruppe.DatumLetztesTraining >= ausgewaehltesDatum &&
                    gruppe.Wochentage.Contains(ausgewaehltesDatum.DayOfWeek.ToString()))
                {
                    TrainingsgruppeUserControl trainingsgruppeUserControl = new TrainingsgruppeUserControl(gruppe, ausgewaehltesDatum);
                    WrapPannelTrainingsgruppen.Children.Add(trainingsgruppeUserControl);
                }
            }




            if (WrapPannelTrainingsgruppen.Children.Count == 0)
            {
                MessageBox.Show("Keine Trainingsgruppen für den ausgewählten Tag gefunden.");
                Log.Logger.Information("Es wurden keine Trainingsgruppen für den ausgewählten Tag gefunden");
            }
        }
    }
}
