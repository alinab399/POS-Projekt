using PresenceLog_SportLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public AnwesenheitsPage()
        {
            InitializeComponent();

            ObservableCollection<Person> personenCollection = new ObservableCollection<Person>();
            personenCollection.Add(new Person("Anna", "Mayer", DateTime.Now));
            personenCollection.Add(new Person("Peter", "Fritz", DateTime.Now));

            ListViewMitglieder.ItemsSource = personenCollection;

        }
        private void AnwesendButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AbwesendButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
