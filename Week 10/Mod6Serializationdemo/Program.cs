using System.Text.Json;
using System.Xml.Serialization;

namespace Mod6Serializationdemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new();
            student.StudentId = 113;
            student.FirstName = "Frank";
            student.LastName = "V";
            student.GPA = 4.5f;

            // JSON Serialization
            Console.WriteLine("JSON Serialization");
            string jsonpath = @"C:\Files\pcad20json.txt";
            if (File.Exists(jsonpath)) File.Delete(jsonpath);

            using (FileStream fs = new FileStream(jsonpath, FileMode.CreateNew, FileAccess.Write))
            {
                JsonSerializer.Serialize(fs, student);
            }
            Console.WriteLine("Data is serialized... Reading it back");

            using (FileStream file = new FileStream(jsonpath, FileMode.Open, FileAccess.Read))
            {
                var obj = JsonSerializer.Deserialize<Student>(file);
                Console.WriteLine($"Student Id: {obj.StudentId}, First Name: {obj.FirstName}, GPA: {obj.GPA}");
            }

            // XML Serialization
            Console.WriteLine("XML Serialization");
            string xmlpath = @"C:\Files\pcad20xml.xml";
            if (File.Exists(xmlpath)) File.Delete(xmlpath);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));

            using (FileStream fs = new FileStream(xmlpath, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fs, student);
            }
            Console.WriteLine("Data is xml serialized");

            using (FileStream stream = new FileStream(xmlpath, FileMode.Open, FileAccess.Read))
            {
                var objxml = (Student)xmlSerializer.Deserialize(stream);
                Console.WriteLine($"Student Id: {objxml.StudentId}, First Name: {objxml.FirstName}, GPA: {objxml.GPA}");
            }
        }
    }
}