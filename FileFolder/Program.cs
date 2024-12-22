using System;
using System.IO;
using System.Runtime.Intrinsics.Arm;

namespace FileFolder;

class Program
{
    public static void Main(string[] args)
    {
        // FileFolderExample();
        FileFolderSwitch();
    }

    public static void FileFolderExample()
    {
        //Creating Folder
        //Use @ for using / 
        string path = @"C:\Users\PremKumarPrithiviraj\OneDrive - Syncfusion\Desktop\Data Structures";
        string folderPath = path + "/FileFolder";
        //Check if folder already exists
        if (!Directory.Exists(folderPath))
        {
            //If not create folder
            System.Console.WriteLine("Creating Folder...");
            Directory.CreateDirectory(folderPath);
            System.Console.WriteLine("Folder Created");
        }
        else
        {
            //If folder already exists
            System.Console.WriteLine("Folder Already Exists...");
        }

        //Creating file
        string filePath = folderPath + "/myfile.txt";
        if (!File.Exists(filePath))
        {
            System.Console.WriteLine("Creating File...");
            File.Create(filePath);
            System.Console.WriteLine("File Created...");
        }
        else
        {
            System.Console.WriteLine("File Already Exists...");
        }
    }

    public static void FileFolderSwitch()
    {

        bool flag = true;
        do
        {
            //Create Delete File and Folder
            System.Console.WriteLine("Select Choice\n1.Create Folder\n2.Create File\n3.Delete Folder\n4.Delete File");
            string path = @"D:\Assignment";
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        //Creating Folder
                        System.Console.Write("Enter Folder Name : ");
                        string folderName = Console.ReadLine();
                        //Check if folder exists
                        if (!Directory.Exists(path + "/" + folderName))
                        {
                            System.Console.WriteLine("Creating Folder...");
                            Directory.CreateDirectory(path + "/" + folderName);
                            System.Console.WriteLine("Folder Created...");
                        }
                        else
                        {
                            System.Console.WriteLine("Folder Already Exists");
                        }
                        break;
                    }
                case 2:
                    {
                        //Creating File
                        System.Console.Write("Enter File Name : ");
                        string fileName = Console.ReadLine();
                        //File Extension
                        System.Console.WriteLine("Enter extension : ");
                        string extension = Console.ReadLine();
                        //Check file Already Exists
                        if (!File.Exists(path + "/" + fileName + "." + extension))
                        {
                            System.Console.WriteLine("Creating File...");
                            File.Create(path + "/" + fileName + "." + extension);
                            System.Console.WriteLine("File Created...");
                        }
                        else
                        {
                            System.Console.WriteLine("File Already Exists");
                        }
                        break;
                    }
                case 3:
                    {
                        //Deleting Folder
                        foreach (string folder in Directory.GetDirectories(path))
                        {
                            //Show all the Folder
                            System.Console.WriteLine(folder);
                        }
                        //Folder to be deleted
                        System.Console.WriteLine("Enter Folder Name to Delete : ");
                        string folderName = Console.ReadLine();
                        foreach (string folder in Directory.GetDirectories(path))
                        {
                            if (folder.Contains(folderName))
                            {
                                //Folder Deleted
                                System.Console.WriteLine("Deleting Folder");
                                Directory.Delete(folder, true);
                                System.Console.WriteLine("Folder Deleted");
                            }
                        }
                        break;
                    }
                case 4:
                    {
                        //Delete File
                        foreach (string file in Directory.GetFiles(path))
                        {
                            //Show all Files
                            System.Console.WriteLine(file);
                        }
                        System.Console.WriteLine("Enter File Name to Delete : ");
                        string fileName = Console.ReadLine();
                        foreach (string file in Directory.GetFiles(path))
                        {
                            //Delete file
                            if (file.Contains(fileName))
                            {
                                System.Console.WriteLine("Deleting File ");
                                File.Delete(file);
                                System.Console.WriteLine("File Deleted");
                            }
                        }
                        break;
                    }
                case 5:
                    {
                        //Exit Do While Loop
                        System.Console.WriteLine("Exit");
                        flag = false;
                        break;
                    }
            }
        } while (flag);
    }
}