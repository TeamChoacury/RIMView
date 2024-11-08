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

namespace RIMView
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

        public void SetLoading(bool loading)
        {
            Message.Visibility = Visibility.Visible;
            Message.Text = "Loading...";
        }

        public void SetImage(string imagePath)
        {
            Img.Source = new BitmapImage(new Uri(imagePath));
        }
    }
}