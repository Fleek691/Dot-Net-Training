using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
namespace Serialization{
class Program
{
    static void Main()
    {
        #region XML Serialization
        // Student s = new Student
        // {
            
        //     Name = "Avishek",
        //     Marks=new List<int>(),
        //     score=new int[] {1,2}
        // };
        // //A bit complex but easy
        // XmlSerializer serializer = new XmlSerializer(typeof(Student));
        
        // using (StringWriter writer = new StringWriter())
        // {
        //     serializer.Serialize(writer, s);
        //     string xmlData = writer.ToString();

        //     Console.WriteLine(xmlData);
        // }

        // //Easier Way
        // // XmlSerializer serializer = new XmlSerializer(s.GetType());
        // // serializer.Serialize(Console.Out,s);



        // //ouput

        // //single value properties get printed in order as u can see but collections are printed in random
        // //  <?xml version="1.0" encoding="utf-8"?>
        //     // <Student xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
        //     //   <scores>
        //     //     <int>1</int>
        //     //     <int>2</int>
        //     //   </scores>
        //     //   <Id>101</Id>
        //     //   <Name>Avishek</Name>
        //     //   <Marks>88.5</Marks>
        //     // </Student>
        #endregion

        #region Json Serialization
        // StudentJson studentJson=new StudentJson{Id=1,Name="Avishek",Marks=new List<int>{1,2,3}};

        
        //  JsonSerializerOptions options = new JsonSerializerOptions
        // {
        //     WriteIndented = true   // makes JSON human-readable
        // };
        // string json = JsonSerializer.Serialize(studentJson, options);

        // Console.WriteLine(json);

        // StudentJson restore=JsonSerializer.Deserialize<StudentJson>(json);
        // System.Console.WriteLine(restore.Id);
        // System.Console.WriteLine(restore.Name);
        // foreach (int mark in restore.Marks)
        //     {
        //         System.Console.WriteLine(mark);
            // }
        #endregion

        #region Delegates
    

        PrintingComapny pc = new PrintingComapny();
        pc.CustomerChoicePrintMessage=PrintingComapny.MethodsA;
        pc.CustomerChoicePrintMessage+=PrintingComapny.MethodsB;
        pc.CustomerChoicePrintMessage+=PrintingComapny.MethodsC;
        pc.CustomerChoicePrintMessage("Avishek");

        // /* Instance method */
        // pc.CustomerChoicePrintMessage = pc.Simple;
        // pc.Print("Avishek");

        // /* Switch behavior at runtime */
        // pc.CustomerChoicePrintMessage = pc.NewYear;
        // pc.Print("Avishek");

        //     /* Switch again */
        // pc.CustomerChoicePrintMessage = pc.Diwali;
        // pc.Print("Avishek");

        #endregion

    }
}

}