using System;
using Microsoft.Data.SqlClient;

class Program1
{
    static void Main()
    {
        string cs =
        "Data Source=FLEEK\\SQLEXPRESS;Initial Catalog=Customer-Order;Integrated Security=True;Encrypt=False;";
        using SqlConnection con = new SqlConnection(cs);

        //some version in place of Database use Initital Catalog keyword
        //# Windows Authentication (Integrated Security)
        //Server=localhost;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;

        // # SQL Login (username/password)
        // Server=localhost;Database=TrainingDB;User Id=sa;Password=YourStrongPassword;TrustServerCertificate=True;
        //keyvault-the Password is provided at run time for safer security
        SqlCommand cmd;
        SqlDataReader reader;
        NewMethod(con, out cmd, out reader);
        #region Query Command - Filter By City (Parameterized)
        Console.Write("Enter City: ");
        string city = Console.ReadLine() ?? "";

        string sqlCity = @"SELECT CustomerId, FullName, City
                            FROM dbo.Customers
                            WHERE City = @city
                            ORDER BY FullName";


        using (SqlCommand cmdCity = new SqlCommand(sqlCity, con))
        {
            cmdCity.Parameters.AddWithValue("@city", city);
            con.Open();
            using SqlDataReader readerCity = cmdCity.ExecuteReader();
            while (readerCity.Read())
            {
                Console.WriteLine($"{readerCity["CustomerId"]} | {readerCity["FullName"]} | {readerCity["City"]}");
            }
            con.Close();
        }
        #endregion


        Console.WriteLine("Enter operation (insert, update, delete): ");
        string op = Console.ReadLine()?.Trim().ToLower() ?? "";

        if (op == "insert")
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine()!);
            Console.Write("Full Name: ");
            string fullName = Console.ReadLine() ?? "";
            Console.Write("City: ");
            string cityInsert = Console.ReadLine() ?? "";
            

            string insertSql = "INSERT INTO dbo.Customers (CustomerId, FullName, City) VALUES (@id, @fullName, @city)";
            using (SqlCommand cmdInsert = new SqlCommand(insertSql, con))
            {
                cmdInsert.Parameters.AddWithValue("@id", id);
                cmdInsert.Parameters.AddWithValue("@fullName", fullName);
                cmdInsert.Parameters.AddWithValue("@city", cityInsert);
                con.Open();
                int rows = cmdInsert.ExecuteNonQuery();
                Console.WriteLine($"Inserted {rows} row(s).");
                con.Close();
            }
        }
        else if (op == "update")
        {
            Console.Write("CustomerId to update: ");
            string id = Console.ReadLine() ?? "";
            Console.Write("New Full Name: ");
            string newName = Console.ReadLine() ?? "";
            Console.Write("New City: ");
            string newCity = Console.ReadLine() ?? "";

            string updateSql = "UPDATE dbo.Customers SET FullName = @newName, City = @newCity WHERE CustomerId = @id";
            using (SqlCommand cmdUpdate = new SqlCommand(updateSql, con))
            {
                cmdUpdate.Parameters.AddWithValue("@newName", newName);
                cmdUpdate.Parameters.AddWithValue("@newCity", newCity);
                cmdUpdate.Parameters.AddWithValue("@id", id);
                con.Open();
                int rows = cmdUpdate.ExecuteNonQuery();
                Console.WriteLine($"Updated {rows} row(s).");
                con.Close();
            }
        }
        else if (op == "delete")
        {
            Console.Write("CustomerId to delete: ");
            string id = Console.ReadLine() ?? "";

            string deleteSql = "DELETE FROM dbo.Customers WHERE CustomerId = @id";
            using (SqlCommand cmdDelete = new SqlCommand(deleteSql, con))
            {
                cmdDelete.Parameters.AddWithValue("@id", id);
                con.Open();
                int rows = cmdDelete.ExecuteNonQuery();
                Console.WriteLine($"Deleted {rows} row(s).");
                con.Close();
            }
        }
        else
        {
            Console.WriteLine("Unknown operation.");
        }
    }

    private static void NewMethod(SqlConnection con, out SqlCommand cmd, out SqlDataReader reader)
    {
        #region Query Command
        string sql = "SELECT CustomerId, FullName, City FROM dbo.Customers";
        cmd = new SqlCommand(sql, con);
        con.Open();
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader["CustomerId"]} | " +
                $"{reader["FullName"]} | " +
                $"{reader["City"]}"
            );
        }
        con.Close();
        #endregion
    }
}


//Select-Query Statement
//other commands-non query
//Count(*) bad prac