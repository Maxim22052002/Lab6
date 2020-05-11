using System;
using System.IO;

namespace Number4_6_
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory(@"C:\Users\USER\Desktop\Lab6\Number4(6)\Lab6_Temp");
            FileInfo fileInfo = new FileInfo(@"C:\Users\USER\Desktop\Lab6\Number1(6)\lab.dat");
            if (!File.Exists(@"C:\Users\USER\Desktop\Lab6\Number4(6)\Lab6_Temp\lab.dat"))
            {
                fileInfo.CopyTo(@"C:\Users\USER\Desktop\Lab6\Number4(6)\Lab6_Temp\lab.dat");
            }
            
            else if(File.Exists(@"C:\Users\USER\Desktop\Lab6\Number4(6)\Lab6_Temp\lab.dat"))
            {
                File.Delete(@"C:\Users\USER\Desktop\Lab6\Number4(6)\Lab6_Temp\lab.dat");
                fileInfo.CopyTo(@"C:\Users\USER\Desktop\Lab6\Number4(6)\Lab6_Temp\lab.dat");

            }
            
            FileStream file = new FileStream(@"C:\Users\USER\Desktop\Lab6\Number4(6)\Lab6_Temp\lab.dat", FileMode.Open);
            BinaryReader reader = new BinaryReader(file);
            FileStream newfile = new FileStream(@"C:\Users\USER\Desktop\Lab6\Number4(6)\Lab6_Temp\lab_backup.dat", FileMode.Create);
            BinaryWriter writer = new BinaryWriter(newfile);
            for(int i = 0; i<file.Length; i++)
            {
                byte bmp = reader.ReadByte();
                writer.Write(bmp);
            }
            
            writer.Close();
            reader.Close();
            FileInfo info = new FileInfo(@"C:\Users\USER\Desktop\Lab6\Number4(6)\Lab6_Temp\lab.dat");
            Console.WriteLine("The size: "+info.Length);
            Console.WriteLine("Last change time: "+info.LastWriteTime);
            Console.WriteLine("Last access time: " + info.LastAccessTime);
        }
    }
}
