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
            DataColumn[] pk = new DataColumn[1];
            pk[0] = _tblProducts.Columns["ProductID"];
            pk[0].AutoIncrement = true;
            _tblProducts.PrimaryKey = pk;
        }

        public DataTable GetAllProducts()
        {
            InitProductTable();
            return _tblProducts;
        }

        public DataRow GetProductById(int id)
        {
            var row = _tblProducts.Rows.Find(id);
            return row;
        }

        public void InsertProduct(string name, decimal price, short quantity)
        {
            var row = _tblProducts.NewRow();
            row["ProductName"] = name;
            row["UnitPrice"] = price;
            row["UnitsInStock"] = quantity;
            _tblProducts.Rows.Add(row);

            _adp.InsertCommand = _cmdBuilder.GetInsertCommand();
            _adp.Update(_tblProducts);
        }

        public void UpdateProduct(int id, string name, decimal price, short quantity)
        {
            var row = GetProductById(id);
            row["ProductName"] = name;
            row["UnitPrice"] = price;
            row["UnitsInStock"] = quantity;

            _adp.UpdateCommand = _cmdBuilder.GetUpdateCommand();
            _adp.Update(_tblProducts);
        }

        public void DeleteProduct(int id)
        {
            var row = GetProductById(id);
            row.Delete();

            _adp.DeleteCommand = _cmdBuilder.GetDeleteCommand();
            _adp.Update(_tblProducts);
        }

        public DataTable SearchProducts(string name)
        {
            string query = "select ProductID, ProductName, UnitPrice, UnitsInStock from Products where ProductName like @pName";

            SqlCommand cmd = new SqlCommand(query, _conn);
            cmd.Parameters.AddWithValue("pName", "%" + name + "%");

            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            if (_ds.Tables.Contains("Products2"))
                _ds.Tables["Products2"].Clear();

            adp.Fill(_ds, "Products2");
            return _ds.Tables["Products2"];
        }
    }
}
