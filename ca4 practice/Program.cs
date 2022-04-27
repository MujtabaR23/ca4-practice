using System;
using System.IO;

namespace ca4_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            graduate[] graduates = new graduate[4];

            string template = "{0,-20}{1,-10}{2,-10}{3,-25}{4,-20}";
            Console.WriteLine(template, "Graduate Number", "Name", "Marks", "Classification", "Project");

            graduates[0] = new graduate("Mujtaba", 87, "Internet Of Things");
            graduates[1] = new graduate("John", 50, "Programming");
            graduates[2] = new graduate("Emma", 80, "Maths");
            graduates[3] = new graduate("Sarah", 45, "Web Design");

            for (int i = 0; i < graduates.Length; i++)
            {
                Console.WriteLine(graduates[i].ToString());
            }

            fileGrades();
        }
        static void fileGrades()
        {
            string lineIn;
            graduate[] graduates = new graduate[10];
            string[] fields = new string[3];
            string template = "{0,-20}{1,-10}{2,-10}{3,-25}{4,-20}";

            try
            {
                FileStream fs = new FileStream("text.csv", FileMode.Open, FileAccess.Read);

                StreamReader inputStream = new StreamReader(fs);

                Console.WriteLine("");
                Console.WriteLine("Graduate Report");
                Console.WriteLine();
                Console.WriteLine(template, "Graduate Number", "Name", "Marks", "Classification", "Project");
                Console.WriteLine();

                lineIn = inputStream.ReadLine();

                while(lineIn != null)
                {
                    for (int i = 0; i < graduates.Length; i++)
                    {
                        fields = lineIn.Split(',');
                        IsInteger(fields[1], "Grade");
                        graduates[i] = new graduate(fields[0], Int32.Parse(fields[1]), fields[2]);
                        Console.WriteLine(graduates[i]);
                        lineIn = inputStream.ReadLine();
                    }
                }
                inputStream.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("File is invalid length");
            }
        }
        static bool IsInteger(string textIn, string itemName)
        {
            bool isOk;
            int num;

            isOk = int.TryParse(textIn, out num);

            if (isOk == true)
                return true;
            else
            {
                Console.WriteLine("{0} must be of type integer", itemName);
                return false;
            }

        }
    }
}
