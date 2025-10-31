using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace F25Week8DisconnectedModel
{
    public class Crud
    {
        private SqlConnection _conn;
        private SqlDataAdapter _adp;
        private SqlCommandBuilder _cmdBuilder;
        private DataSet _ds;
        private DataTable _tblProducts;

        public Crud()
        {
            _conn = new SqlConnection(Data.GetConnectionString());
            _ds = new DataSet();

            InitProductTable();
        }

        private void InitProductTable()
        {
            string query = "select ProductID, ProductName, UnitPrice, UnitsInStock from Products";

            _adp = new SqlDataAdapter(query, _conn);
            _cmdBuilder = new SqlCommandBuilder(_adp);

            _adp.Fill(_ds, "Products");
            _tblProducts = _ds.Tables["Products"];

            // define a primary key

        }

        public DataTable GetAllProducts()
        {
            InitProductTable();
            return _tblProducts;
        }
    }
}
