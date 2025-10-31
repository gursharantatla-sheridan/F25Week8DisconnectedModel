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

namespace F25Week8DisconnectedModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Data data = new Data();
        Crud crud = new Crud();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoadAllProducts_Click(object sender, RoutedEventArgs e)
        {
            //grdProducts.ItemsSource = data.GetAllProducts().DefaultView;
            grdProducts.ItemsSource = crud.GetAllProducts().DefaultView;
        }

        private void btnShowWindow2_Click(object sender, RoutedEventArgs e)
        {
            DataSetWithMultipleTables win2 = new DataSetWithMultipleTables();
            win2.Show();
        }
    }
}