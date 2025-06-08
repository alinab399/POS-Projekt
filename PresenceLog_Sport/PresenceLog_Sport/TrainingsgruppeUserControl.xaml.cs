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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresenceLog_Sport
{
    /// <summary>
    /// Interaktionslogik für TrainingsgruppeUserControl.xaml
    /// </summary>
    public partial class TrainingsgruppeUserControl : UserControl
    {
        public Trainingsgruppe Trainingsgruppe { get; set; }
        public TrainingsgruppeUserControl(Trainingsgruppe trainingsgruppe)
        {
            InitializeComponent();

            this.Height = 150;
            this.Width = 150;
            this.Trainingsgruppe = trainingsgruppe;

            LabelUserControlTitel.Content = trainingsgruppe.Name;

        }

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AnwesenheitsPage anwesenheitPage = new AnwesenheitsPage(Trainingsgruppe);

            // Typprüfung und Typumwandlung (Casting):
            //Es wird geprüft: Ist das aktuelle Hauptfenster tatsächlich vom Typ MainWindow? Falls ja, wird es in die Variable mainWindow gespeichert.
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.MainFrame.Navigate(anwesenheitPage);
            }
        }
    }
}
