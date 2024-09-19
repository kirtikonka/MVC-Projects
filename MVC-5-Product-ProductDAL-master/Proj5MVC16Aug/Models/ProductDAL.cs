using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proj5MVC16Aug.Models
{
    public class ProductDAL
    {
        string cf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
        SqlConnection conn;
        public ProductDAL() 
        {
            conn = new SqlConnection(cf);
            conn.Open();
        }
        public List<Product> GetAllProducts()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("sp_show", conn);  //we can also use 'exec sp_show'
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            List<Product> products = new List<Product>();
            foreach(DataRow dr in dt.Rows)
            {
                products.Add(new Product
                {
                    Id = int.Parse(dr["id"].ToString()),
                    pname = dr["pname"].ToString(),
                    pcat = dr["pcat"].ToString(),
                    price = double.Parse(dr["price"].ToString())
                });
            }
            return products;
        }
    }
}