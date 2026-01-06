using System;
using System.IO;
using System.Xml.Serialization;
namespace Serialization{
class Program
{
    static void Main()
    {
        Student s = new Student
        {
            
            Name = "Avishek",
            Marks=new List<int>(),
            score=new int[] {1,2}
        };
        //A bit complex but easy
        XmlSerializer serializer = new XmlSerializer(typeof(Student));
        
        using (StringWriter writer = new StringWriter())
        {
            serializer.Serialize(writer, s);
            string xmlData = writer.ToString();

            Console.WriteLine(xmlData);
        }

        //Easier Way
        // XmlSerializer serializer = new XmlSerializer(s.GetType());
        // serializer.Serialize(Console.Out,s);



        //ouput

        //single value properties get printed in order as u can see but collections are printed in random
        //  <?xml version="1.0" encoding="utf-8"?>
            // <Student xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
            //   <scores>
            //     <int>1</int>
            //     <int>2</int>
            //   </scores>
            //   <Id>101</Id>
            //   <Name>Avishek</Name>
            //   <Marks>88.5</Marks>
            // </Student>

    }
}
}