using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

class Program2
{
    static void Main(string[] args)
    {
        string cs =
    "Data Source=FLEEK\\SQLEXPRESS;Initial Catalog=Customer-Order;Integrated Security=True;Encrypt=False;";
        string sql = "SELECT CustomerId, FullName, City FROM dbo.Customers";
        DataSet ds = new DataSet();
        using (var con = new SqlConnection(cs))
        using (var cmd = new SqlCommand(sql, con))
        {
            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
        }
        ds.WriteXml("TestData");


    }
}
