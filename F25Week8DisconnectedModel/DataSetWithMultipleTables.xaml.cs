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
using System.Data;
using Microsoft.Data.SqlClient;

namespace F25Week8DisconnectedModel
{
    /// <summary>
    /// Interaction logic for DataSetWithMultipleTables.xaml
    /// </summary>
    public partial class DataSetWithMultipleTables : Window
    {
        public DataSetWithMultipleTables()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(Data.GetConnectionString());

            string query1 = "select * from Categories";
            string query2 = "select * from Products";

            SqlDataAdapter adp = new SqlDataAdapter(query1, conn);
            DataSet ds = new DataSet();
            adp.Fill(ds, "Categories");

            adp = new SqlDataAdapter(query2, conn);
            adp.Fill(ds, "Products");

            DataTable tblCats = ds.Tables["Categories"];
            DataTable tblProds = ds.Tables["Products"];

            grdCategories.ItemsSource = tblCats.DefaultView;
            grdProducts.ItemsSource = tblProds.DefaultView;
        }
    }
}
