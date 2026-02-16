using Microsoft.Data.SqlClient;
using System.Data;
public class Program
{
    public static void Main()
    {
        //Connected Architecture
        // string cs ="Data Source=FLEEK\\SQLEXPRESS;Initial Catalog=Customer-Order;Integrated Security=True;Encrypt=False;";
        // using var con=new SqlConnection(cs);
        // using var cmd=new SqlCommand("SELECT * FROM dbo.Customers;",con);
        // con.Open();
        // using var reader=cmd.ExecuteReader();
        // while (reader.Read())
        // {
        //     int id=reader.GetInt32(0);
        //     string name=reader.GetString(1);
        //     string city=reader.GetString(2);
        //     string segment=reader.GetString(3);
        //     bool IsActive=reader.GetBoolean(4);
        //     DateTime time=reader.GetDateTime(5);
        //     Console.WriteLine($"{id} | {name} | {city} | {segment} | {IsActive} | {time}" );
        // }
        //Disconnected Archit

        string cs = "Data Source=FLEEK\\SQLEXPRESS;Initial Catalog=Customer-Order;Integrated Security=True;Encrypt=False;";

        DataTable customers = new DataTable();

        using var con = new SqlConnection(cs);
        using var cmd = new SqlCommand("SELECT * FROM dbo.Customers;", con);
        using (var da = new SqlDataAdapter(cmd))
        {
            con.Open();
            da.Fill(customers);
        }

        // ✅ Connection is closed here, but data is available
        Console.WriteLine("Rows loaded: " + customers.Rows.Count);
        foreach (DataRow row in customers.Rows)
        {
            Console.WriteLine($"{row["CustomerId"]} | {row["FullName"]} | {row["City"]} | {row["Segment"]} | {row["IsActive"]} | {row["CreatedOn"]}");
        }

        string city = "Chennai";
        using var cmd1 = new SqlCommand("SELECT CustomerId, FullName, City, Marks FROM Students WHERE City = @City", con);

        cmd.Parameters.AddWithValue("@City", city);


        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(reader["FullName"]);
        }
        //LINQ: Where + Select (Filter + Projection)
        var usage = customers.AsEnumerable()
        .Where(r => r.Field<int>("CustomerId") >= 103)
        .Select(r => new
        {
            Id = r.Field<int>("CustomerId"),
            Name = r.Field<string>("FullName"),
        })
        .ToList();
        Console.WriteLine("Sorted by Marks desc, then Name:");
        foreach (var s in usage)
            Console.WriteLine($"{s.Id} | {s.Name} ");

        // LINQ: OrderBy + ThenBy (Sorting)
        var rows = customers.AsEnumerable();
        var activeCustomers = rows.Where(e => e.Field<bool>("IsActive") == true).
                                Select(e => e.Field<string>("FullName")).ToList();
        activeCustomers.ForEach(Console.WriteLine);
        var sorted = customers.AsEnumerable()
        .OrderByDescending(r => r.Field<int>("CustomerId"))
        .ThenBy(r => r.Field<string>("FullName"))
        .Select(r => new
        {
            Name = r.Field<string>("FullName"),
            id = r.Field<int>("CustomerId")
        })
        .ToList();
        Console.WriteLine("Sorted by Marks desc, then Name:");
        foreach (var s in sorted)
            Console.WriteLine($"{s.Name} - {s.id}");
        // Linq to GROUPBY city
        var byCity = customers.AsEnumerable()
        .GroupBy(r => r.Field<string>("City"))
        .Select(g => new
        {
            City = g.Key,
            Count = g.Count(),
            AvgMarks = (int)g.Average(x => x.Field<int>("CustomerId"))
        })
        .OrderByDescending(x => x.AvgMarks)
        .ToList();

        foreach (var g in byCity)
            Console.WriteLine($"{g.City} | Count={g.Count} | AvgMarks={g.AvgMarks}");

        con.Close();
        DataTable enrollments = new DataTable();
        DataTable courses = new DataTable();



        using (var da1 = new SqlDataAdapter("SELECT CustomerId, FullName FROM Customers", con))
            da1.Fill(customers);

        using (var da2 = new SqlDataAdapter("SELECT CustomerId,Amount FROM Orders", con))
            da2.Fill(enrollments);

        
        var report =
                    from s in customers.AsEnumerable()
                    join e in enrollments.AsEnumerable()
                    on s.Field<int>("CustomerID") equals e.Field<int>("CustomerID")
                    join c in courses.AsEnumerable()
                    on e.Field<int>("CustomerID") equals c.Field<int>("CustomerID")
                    where s.Field<bool>("IsActive") == true
                    select new
                    {
                        
                        Marks = s.Field<int>("CustomerID"),
                        
                    };

        foreach (var row in report)
            Console.WriteLine($" {row.Marks}");


    }
}