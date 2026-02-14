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
        string sql = "SELECT * FROM dbo.Customers; SELECT * FROM dbo.Orders";
        DataSet ds = new DataSet();
        using (var con = new SqlConnection(cs))
        using (var cmd = new SqlCommand(sql, con))
        {
            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
        }
        ds.WriteXml("TestData");

        Console.WriteLine(ds.Tables.Count);
        foreach (DataColumn item in ds.Tables[0].Columns)
        {
            System.Console.WriteLine(item.ColumnName + "\t");
        }
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            foreach (var item in row.ItemArray)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
        }

        // INSERT Operation
        Console.WriteLine("\n--- INSERT OPERATION ---");
        InsertCustomer(ds, cs);
        Console.WriteLine("\nData After INSERT:");
        DisplayTableData(ds);

        // UPDATE Operation
        Console.WriteLine("\n--- UPDATE OPERATION ---");
        UpdateCustomer(ds, cs);
        Console.WriteLine("\nData After UPDATE:");
        DisplayTableData(ds);

        // DELETE Operation
        Console.WriteLine("\n--- DELETE OPERATION ---");
        DeleteCustomer(ds, cs);
        Console.WriteLine("\nData After DELETE:");
        DisplayTableData(ds);
    }

    static void DisplayTableData(DataSet ds)
    {
        if (ds.Tables[0].Rows.Count == 0)
        {
            Console.WriteLine("No records found!");
            return;
        }

        // Print column headers
        foreach (DataColumn col in ds.Tables[0].Columns)
        {
            Console.Write(col.ColumnName + "\t");
        }
        Console.WriteLine();

        // Print rows
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            foreach (var item in row.ItemArray)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
        }
    }

    static void InsertCustomer(DataSet ds, string cs)
    {
        int newId = new Random().Next(1000, 9999);
        DataRow newRow = ds.Tables[0].NewRow();
        newRow["CustomerId"] = newId;
        newRow["FullName"] = "John Doe";
        newRow["City"] = "Bangalore";
        newRow["Segment"] = "Retail";
        newRow["IsActive"] = true;
        newRow["CreatedOn"] = DateTime.Now;
        ds.Tables[0].Rows.Add(newRow);

        using (var con = new SqlConnection(cs))
        using (var cmd = new SqlCommand("SELECT * FROM dbo.Customers", con))
        {
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(ds, "Table");
            Console.WriteLine($"Record Inserted Successfully! (CustomerId: {newId})");

            // Reload data from database
            ds.Tables[0].Clear();
            adapter.Fill(ds.Tables[0]);
        }
    }

    static void UpdateCustomer(DataSet ds, string cs)
    {
        if (ds.Tables[0].Rows.Count > 0)
        {
            ds.Tables[0].Rows[0]["FullName"] = "Updated Name";
            ds.Tables[0].Rows[0]["Segment"] = "Corporate";

            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("SELECT * FROM dbo.Customers", con))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "Table");
                Console.WriteLine("Record Updated Successfully!");

                // Reload data from database
                ds.Tables[0].Clear();
                adapter.Fill(ds.Tables[0]);
            }
        }
    }

    static void DeleteCustomer(DataSet ds, string cs)
    {
        // Delete the newly inserted customer (John Doe) which has no orders
        DataRow[] rowsToDelete = ds.Tables[0].Select("FullName = 'John Doe'");
        if (rowsToDelete.Length > 0)
        {
            rowsToDelete[0].Delete();

            using (var con = new SqlConnection(cs))
            using (var cmd = new SqlCommand("SELECT * FROM dbo.Customers", con))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds, "Table");
                Console.WriteLine("Record Deleted Successfully!");

                // Reload data from database
                ds.Tables[0].Clear();
                adapter.Fill(ds.Tables[0]);
            }
        }
        else
        {
            Console.WriteLine("Record with FullName 'John Doe' not found!");
        }
    }
}
