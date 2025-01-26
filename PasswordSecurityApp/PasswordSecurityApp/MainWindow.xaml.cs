using System.Diagnostics;
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

namespace PasswordSecurityApp
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

        private void Test_Click(object sender, RoutedEventArgs e)
        {

            string testerPath = "C:..\\..\\..\\..\\..\\PassWordStrengthTester\\PassWordStrengthTester\\bin\\Debug\\net8.0\\PassWordStrengthTester.exe";

            Process process = new Process();
            process.StartInfo.FileName = testerPath;
            process.StartInfo.Arguments = inputBox.Text.ToString();
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;

            process.Start();

            string output = process.StandardOutput.ReadToEnd();

            outputBox.Text = output;
        }
    }
}