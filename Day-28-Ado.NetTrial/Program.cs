using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string cs =
        "Data Source=FLEEK\\SQLEXPRESS;Initial Catalog=Customer-Order;Integrated Security=True;Encrypt=False;";

        string sql = "SELECT CustomerId, FullName, City FROM dbo.Customers";

        using SqlConnection con = new SqlConnection(cs);
        using SqlCommand cmd = new SqlCommand(sql, con);

        con.Open();

        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader["CustomerId"]} | " +
                $"{reader["FullName"]} | " +
                $"{reader["City"]}"
            );
        }
    }
}
