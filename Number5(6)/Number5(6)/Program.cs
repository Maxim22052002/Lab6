using System;
using System.IO;

namespace Number5_6_
{
    class Program
    {
        
        
            static void Main(string[] args)
            {
                string namefile = Console.ReadLine();
                FileStream file = new FileStream(@"D:\рисунки\" + namefile, FileMode.Open);
                BinaryReader binary = new BinaryReader(file);
                file.Seek(2, SeekOrigin.Begin);
                int size = binary.ReadInt32();
                file.Seek(12, SeekOrigin.Current);
                int width = binary.ReadInt32();
                int high = binary.ReadInt32();
                file.Seek(2, SeekOrigin.Current);
                short BitInPx = binary.ReadInt16();


                int comprtype = binary.ReadInt32();
                string Comprtype = string.Empty;
                switch (comprtype)
                {
                    case 0:
                        Comprtype = "Без сжатия";
                        break;
                    case 1:
                        Comprtype = "8 bit RLE сжатие";
                        break;
                    case 2:
                        Comprtype = "4 bit RLE сжатие";
                        break;
                }
                file.Seek(4, SeekOrigin.Current);
                int horexp = binary.ReadInt32();
                int verexp = binary.ReadInt32();
                Console.WriteLine("Размер: "+size);
                Console.WriteLine("Ширина: "+width);
                Console.WriteLine("Высота: "+high);
                Console.WriteLine("Бит на пиксель: "+BitInPx);
                Console.WriteLine("Горизонтальное разрешение: "+horexp);
                Console.WriteLine("Вертикальное разрешение: "+verexp);
                Console.WriteLine("Тип сжатия: "+Comprtype);
                binary.Close();



            }
    }
}
