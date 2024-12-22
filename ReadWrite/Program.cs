using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ReadWrite;

class Program
{
    public static void Main(string[] args)
    {
        //Creating Folder
        if (!Directory.Exists("test"))
        {
            Directory.CreateDirectory("test");
        }
        else
        {
            System.Console.WriteLine("Test Folder Already Exists...");
        }

        //Creating CSV File
        if (!File.Exists("test/dataCSV.csv"))
        {
            //After Creating Close the File
            File.Create("test/dataCSV.csv").Close();
        }
        else
        {
            System.Console.WriteLine("CSV File already Exists...");
        }

        //Creating JSON File
        if (!File.Exists("test/dataJSON.json"))
        {
            //After Creating Close the File
            File.Create("test/dataJSON.json").Close();
        }
        else
        {
            System.Console.WriteLine("JSON File already Exists...");
        }

        List<Student> students = new List<Student>();
        students.Add(new Student() { Name = "Prem", FatherName = "Kumar", DOB = DateTime.Now.AddYears(-21), StudentGender = GenderDetail.Male });
        students.Add(new Student() { Name = "Jeya", FatherName = "Kumar", DOB = DateTime.Now.AddYears(-21), StudentGender = GenderDetail.Male });
        students.Add(new Student() { Name = "Alish", FatherName = "Kumar", DOB = DateTime.Now.AddYears(-21), StudentGender = GenderDetail.Male });
        WriteCSV(students);
        ReadCSV();
        WriteToJSON(students);
        ReadJSON();
    }

    //writing in CSV File
    static void WriteCSV(List<Student> students)
    {
        //Stream Writer
        StreamWriter streamWriter = new StreamWriter("test/dataCSV.csv");
        foreach (Student student in students)
        {
            string line = student.Name + "," + student.FatherName + "," + student.DOB.ToString("dd/MM/yyyy") + "," + student.StudentGender;
            streamWriter.WriteLine(line);
        }
        //Close
        streamWriter.Close();
    }

    //Read from CSV File
    static void ReadCSV()
    {
        List<Student> studentsRead = new List<Student>();
        //To store Read Data
        StreamReader streamReader = new StreamReader("test/dataCSV.csv");
        //Stream Reader
        string line = streamReader.ReadLine();
        while (line != null)
        {
            string[] values = line.Split(",");
            if (values[0] != null)
            {
                Student studentDetail = new Student() { Name = values[0], FatherName = values[1], DOB = DateTime.ParseExact(values[2], "dd/MM/yyyy", null), StudentGender = Enum.Parse<GenderDetail>(values[3]) };
                studentsRead.Add(studentDetail);
            }
            line = streamReader.ReadLine();
        }
        foreach (Student student in studentsRead)
        {
            System.Console.WriteLine(student.Name + " " + student.FatherName + " " + student.DOB + " " + student.StudentGender);
            System.Console.WriteLine();
        }
    }

    static void WriteToJSON(List<Student> students)
    {
        //Stream Writer
        StreamWriter streamWriter=new StreamWriter("test/dataJSON.json");
        //For indendation 
        //Set JsonSerializer Option to true
        var option=new JsonSerializerOptions{
            WriteIndented=true
        };
        //Converted to json 
        string data=JsonSerializer.Serialize(students,option);
        //writing to File
        streamWriter.Write(data);
        streamWriter.Close();
    }

    static void ReadJSON()
    {
        //JsonSerializer.Desrialize to read JSON File
        List<Student> students=JsonSerializer.Deserialize<List<Student>>(File.ReadAllText("test/dataJSON.json"));
         foreach (Student student in students)
        {
            System.Console.WriteLine(student.Name + " " + student.FatherName + " " + student.DOB + " " + student.StudentGender);
            System.Console.WriteLine();
        }
    }
}