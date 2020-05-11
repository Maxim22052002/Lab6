using System;
using System.IO;

namespace Number2_6_
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file = new FileStream(@"c:\Users\USER\Desktop\Lab6\Number2(6)\file.dat", FileMode.Create);
            BinaryWriter wr = new BinaryWriter(file);
            for(int i = 1; i <= 100; i++)
            {
                wr.Write(i);
                double x = 1 / i;
                wr.Write(x);
            }
            wr.Close();
           // file.Close();
            FileStream oldfile = new FileStream(@"c:\Users\USER\Desktop\Lab6\Number2(6)\file.dat", FileMode.Open);
            BinaryReader read = new BinaryReader(oldfile);
            double[] mas = new double[100];
            for(int i = 0; i < mas.Length; i++)
            {
                oldfile.Seek(4, SeekOrigin.Current);
                mas[i] = read.ReadDouble();
                
            }
            read.Close();
           // oldfile.Close();
            FileStream newfile = new FileStream(@"c:\Users\USER\Desktop\Lab6\Number2(6)\newfile.dat", FileMode.Create);
            BinaryWriter wrb = new BinaryWriter(newfile);
            for(int i = 0; i < mas.Length; i++)
            {
                wrb.Write(mas[i]);
            }
            wrb.Close();
            //newfile.Close();
        }
    }
}
