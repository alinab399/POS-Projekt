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
        ObservableCollection<Person> personenCollection = new ObservableCollection<Person>();
        public AnwesenheitsPage()
        {
            InitializeComponent();
            //PersonenCollection personen = new PersonenCollection();

          
            personenCollection.Add(new Person("Anna", "Mayer", DateTime.Now));
            personenCollection.Add(new Person("Peter", "Fritz", DateTime.Now));

  

            ListViewAnwesenheit.ItemsSource = personenCollection;

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
    }
}
