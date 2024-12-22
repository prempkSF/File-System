using System;
using System.IO;
namespace ReadWriteTXT;

class Program
{
    public static void Main(string[] args)
    {
        //Creating Folder and File
        if (!Directory.Exists("txtFiles"))
        {
            Directory.CreateDirectory("txtFiles");
            System.Console.WriteLine("Folder Created");
        }
        else
        {
            System.Console.WriteLine("Folder Already Exists...");
        }
        if (!File.Exists("txtFiles/file.txt"))
        {
            File.Create("txtFiles/file.txt").Close();
            System.Console.WriteLine("File Created...");
        }
        else
        {
            System.Console.WriteLine("File Already Exists...");
        }

        do
        {
            //Reading and Writing in File
            System.Console.WriteLine("Select Choice \n1.Read File\n2.Write File");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        //Reading
                        StreamReader streamReader = new StreamReader("D:/Assignment/prem.txt");
                        string data = streamReader.ReadLine();
                        while (data != null)
                        {
                            System.Console.WriteLine(data);
                            data = streamReader.ReadLine();
                        }
                        streamReader.Close();
                        break;
                    }
                case 2:
                {
                    //Reading all Lines and convert it to a array
                    string[] contents=File.ReadAllLines("D:/Assignment/prem.txt");
                    StreamWriter streamWriter=new StreamWriter("D:/Assignment/prem.txt");
                    string oldLine="";
                    foreach(string content in contents)
                    {
                        oldLine=oldLine+content+"\n";
                    }
                    System.Console.WriteLine("Enter Line to Write : ");
                    string data=Console.ReadLine();
                    //User Line to add
                    oldLine=oldLine+data;
                    //Writing to the file 
                    //Old and new data
                    streamWriter.WriteLine(oldLine);
                    //Closing object
                    streamWriter.Close();
                    break;
                }
            }

        } while (true);

    }
}