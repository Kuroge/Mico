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

namespace Mico
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TimeSet_Click(object sender, RoutedEventArgs e)
        {
            int time;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            if (TimeType.Text.Equals("Horas"))
            {
                time = Convert.ToInt32(Time.Text) * 3600;
                startInfo.Arguments = $"/C shutdown -s -t {time.ToString()}";
            }else if (TimeType.Text.Equals("Minutos"))
            {
                time = Convert.ToInt32(Time.Text) * 60;
                startInfo.Arguments = $"/C shutdown -s -t {time.ToString()}";
            }
            else
            {
                startInfo.Arguments = $"/C shutdown -s -t {Time.Text}";
            }
            process.StartInfo = startInfo;
            process.Start();
            ByeLabel.Content = "¡Buenas noches!";
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = $"/C shutdown -a";
            process.StartInfo = startInfo;
            process.Start();
            ByeLabel.Content = ":(";

        }

        private void TimeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _1.Visibility = Visibility.Hidden;
            _2.Visibility = Visibility.Visible;
            
        }
    }
}
