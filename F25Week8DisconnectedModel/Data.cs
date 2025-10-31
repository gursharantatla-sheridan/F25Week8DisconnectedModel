using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace F25Week8DisconnectedModel
{
    public class Data
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;
        }

        public DataTable GetAllProducts()
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());

            string query = "select ProductID, ProductName, UnitPrice, UnitsInStock from Products";
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);

            DataSet ds = new DataSet();
            adp.Fill(ds, "Products");

            DataTable? tbl = ds.Tables["Products"];
            return tbl;
        }
    }
}
