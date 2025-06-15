using PresenceLog_SportLib;
using Serilog;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .WriteTo.File("data/log/PresenceLog_Sport.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            StartPage startPage = new StartPage();
            MainFrame.Navigate(startPage);

            Log.Logger.Information("StartPage wird angezeigt");
            
        }
    }
}