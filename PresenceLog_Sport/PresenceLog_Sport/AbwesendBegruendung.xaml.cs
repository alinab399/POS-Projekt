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
        public AbwesendBegruendung()
        {
            InitializeComponent();
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            string begruendung = TextBoxBegruendung.Text;

            this.DialogResult = true;
            this.Close();
        }

        private void ButtonAbbrechen_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
