using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PresenceLog_Sport
{
    /// <summary>
    /// Interaktionslogik für Personhinzufuegen.xaml
    /// </summary>
    public partial class Personhinzufuegen : Window
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public DateTime Geburtsdatum { get; set; }
        public Personhinzufuegen()
        {
            InitializeComponent();
        }

        private void OkayBtn_Click(object sender, RoutedEventArgs e)
        {
            Vorname = TextBoxVorname.Text;
            Nachname = TextBoxNachname.Text;
            Geburtsdatum = DatePickerGeburtsdatum.SelectedDate.Value;

            this.DialogResult = true;
            this.Close();

            Log.Logger.Information("Person-hinzufügen-Fenster wurde durch OK-Button geschlossen");
            Log.Logger.Information("Neue Person wurde hinzugefügt.");
        }

        private void AbbrechenBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();

            Log.Logger.Information("Person-hinzufügen-Fenster wurde durch OK-Button geschlossen");
        }
    }
}
