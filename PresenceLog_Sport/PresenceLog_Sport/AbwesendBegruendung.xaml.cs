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
    /// Interaction logic for AbwesendBegruendung.xaml
    /// </summary>
    public partial class AbwesendBegruendung : Window
    {
        public string Begruendung {  get; set; }
        public AbwesendBegruendung()
        {
            InitializeComponent();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            Begruendung = TextBoxBegruendung.Text;

            this.DialogResult = true;
            this.Close();

            Log.Logger.Information("Begründungs Fenster der Abwesenheit durch OK-Button geschlossen");
        }

        private void ButtonAbbrechen_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();

            Log.Logger.Information("Begründungs Fenster der Abwesenheit durch Abbrechen-Button geschlossen");
        }

        private void TextBoxBegruendung_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxBegruendung.Text))
            {
                TextBoxBegruendung.Background = Brushes.Red;

                Log.Logger.Warning("Begründungseingabefeld ist leer");
            }

            else
            {
                TextBoxBegruendung.Background = Brushes.White;
            }
        }
    }
}
