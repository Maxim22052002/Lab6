using System;
using System.IO;

namespace Number3_6_
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader readfile = File.OpenText("testFile.txt");
            int counter = 0;
            string str = readfile.ReadToEnd();
            char[] array = str.ToCharArray();
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] == '<')
                {
                    array[i] = '{';
                    counter++;
                }
                if (array[i] == '>')
                {
                    array[i] = '}';
                    counter++;
                }
                

            }
            str = String.Concat(array);
            readfile.Close();
            StreamWriter newfile = File.CreateText("newtestFile.txt");
            Console.WriteLine();
            newfile.WriteLine(str);
            newfile.Close();
            Console.WriteLine("Number of changes: "+counter);
            

            
            
            
        }
    }
}
