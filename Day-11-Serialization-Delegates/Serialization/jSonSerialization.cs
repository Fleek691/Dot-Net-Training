// using System.Text.Json;
// using System.Text.Json.Serialization;
// using Microsoft.Xml

// // public class StudentJson
// // {
// //     public int Id{get;set;}
// //     public string Name{get;set;}
// //     public List<int> Marks{get;set;}
// // }
// [XmlSerializerAssembly]
// public class Student
// {
//     [JsonPropertyName("student_name")]
//     public string Name { get; set; }
//     [JsonIgnore]
//     public int Marks { get; set; }
// }
// public class Program3
// {
//     public static void Main()
//     {
//         Student s = new Student { Name = "Avishek", Marks = 100 };
//         string json = JsonSerializer.Serialize(s);
//         System.Console.WriteLine(json);
//         Student newStudent = JsonSerializer.Deserialize<Student>(json);
//         System.Console.WriteLine(newStudent.Name);
//         File.WriteAllText("student.json", json);
//         string data = File.ReadAllText("student.json");

//         Student s2 = JsonSerializer.Deserialize<Student>(data);
//         System.Console.WriteLine(s2.Marks);
//         var options = new JsonSerializerOptions
//         {
//             WriteIndented = true
//         };
//         string json1 = JsonSerializer.Serialize(s, options);
//         System.Console.WriteLine(json1);
//         List<Student> students = new List<Student>{new Student { Name = "Aman", Marks = 90 },
//                                                                 new Student { Name = "Neha", Marks = 85 }
//     };

//         string json2 = JsonSerializer.Serialize(students);
//         System.Console.WriteLine(json2);
//         XmlSerializer serializer = new XmlSerializer(typeof(Student));

//         using (FileStream fs = new FileStream("student.xml", FileMode.Create))
//         {
//             serializer.Serialize(fs, s);
//         }






//     }
// }