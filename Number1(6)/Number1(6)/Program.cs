using System;
using System.IO;

namespace Number1_6_
{
    class Program
    {


        enum EnumType : int
        {
            K,
            O
        }
        struct PriceList
        {
            public string nameofprod;
            public EnumType type;
            public double price;
            public int quantity;
        }
        static void Main(string[] args)
        {

            PriceList[] pricelist = new PriceList[50];
            DateTime[] dateTimes = new DateTime[50];
            string[] explainer = new string[50];
            int pos = 3;
            pricelist[0].nameofprod = "Папка"; pricelist[0].type = EnumType.K; pricelist[0].price = 4.75; pricelist[0].quantity = 400;
            pricelist[1].nameofprod = "Бумага A4 (пачка)"; pricelist[1].type = EnumType.K; pricelist[1].price = 45.90; pricelist[1].quantity = 100;
            pricelist[2].nameofprod = "Калькулятор"; pricelist[2].type = EnumType.O; pricelist[2].price = 411.00; pricelist[2].quantity = 10;
            if (!File.Exists(@"C:\Users\USER\Desktop\Lab6\Number1(6)\lab.dat"))
            {
                FileStream fss = new FileStream(@"C:\Users\USER\Desktop\Lab6\Number1(6)\lab.dat", FileMode.Create);
                BinaryWriter biwriter = new BinaryWriter(fss);
                biwriter.Write(pricelist[0].nameofprod); biwriter.Write(pricelist[0].type.ToString()); biwriter.Write(pricelist[0].price); biwriter.Write(pricelist[0].quantity);
                biwriter.Write(pricelist[1].nameofprod); biwriter.Write(pricelist[1].type.ToString()); biwriter.Write(pricelist[1].price); biwriter.Write(pricelist[1].quantity);
                biwriter.Write(pricelist[2].nameofprod); biwriter.Write(pricelist[2].type.ToString()); biwriter.Write(pricelist[2].price); biwriter.Write(pricelist[2].quantity);
                biwriter.Close();
            }
            else
            {


                bool mark = true;

                int datepos = 0;
                while (mark)
                {
                    Console.WriteLine("1 - Просмотр таблицы\n2 - Добавить запись\n3 - Удалить запись\n4 - Обновить запись\n5 - Поиск записей\n6 - Просмотреть лог\n7 - Выход");
                    string inpusolution = Console.ReadLine();
                    switch (inpusolution)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine(File.ReadAllText(@"C:\Users\USER\Desktop\Lab6\Number1(6)\lab.dat"));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case "2":
                            Console.Clear();
                            Console.WriteLine("Введите наименование товара: ");
                            pricelist[pos].nameofprod = Console.ReadLine();
                            Console.WriteLine("Введите тип товара: ");
                            pricelist[pos].type = (EnumType)Enum.Parse(typeof(EnumType), Console.ReadLine());
                            Console.WriteLine("Введите Цена за 1 шт (грн): ");
                            pricelist[pos].price = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Введите количество товара: ");
                            pricelist[pos].quantity = Convert.ToInt32(Console.ReadLine());
                            dateTimes[datepos] = DateTime.Now;
                            string addnote = pricelist[3].nameofprod;
                            explainer[datepos] = $"запись добавлена \"{addnote}\"";
                            datepos++;
                            pos++;
                            Console.Clear();
                            break;
                        case "3":
                            Console.Clear();
                            Console.WriteLine("Введите номер удаляемой записи: ");
                            int numdel = Convert.ToInt32(Console.ReadLine());
                            string numrec = pricelist[numdel].nameofprod;
                            explainer[datepos] = $"запись удалена \"{numrec}\"";
                            for (int i = numdel; i < pos; i++)
                            {
                                pricelist[i].nameofprod = pricelist[i + 1].nameofprod;
                                pricelist[i].type = pricelist[i + 1].type;
                                pricelist[i].price = pricelist[i + 1].price;
                                pricelist[i].quantity = pricelist[i + 1].quantity;
                            }
                            pos--;
                            dateTimes[datepos] = DateTime.Now;
                            datepos++;

                            Console.Clear();
                            break;
                        case "4":
                            Console.Clear();
                            Console.WriteLine("Введите номер редактируемой записи: ");
                            int numberred = Convert.ToInt32(Console.ReadLine());
                            string postupdated = pricelist[numberred].nameofprod;
                            Console.WriteLine("Введите новое наименование товара: ");
                            pricelist[numberred].nameofprod = Console.ReadLine();
                            Console.WriteLine("Введите новый тип товара: ");
                            pricelist[numberred].type = (EnumType)Enum.Parse(typeof(EnumType), Console.ReadLine());
                            Console.WriteLine("Введите новую Цену за 1 шт (грн):");
                            pricelist[numberred].price = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Введите новое количество товара: ");
                            pricelist[numberred].quantity = Convert.ToInt32(Console.ReadLine());
                            dateTimes[datepos] = DateTime.Now;
                            explainer[datepos] = $"запись обновлена \"{postupdated}\"";
                            datepos++;
                            Console.Clear();
                            break;
                        case "5":
                            Console.Clear();
                            Console.WriteLine("Введите минимальную цену: ");
                            double minprice = Convert.ToDouble(Console.ReadLine());
                            for (int i = 0; i < pos; i++)
                            {
                                if (pricelist[i].price > minprice)
                                {
                                    Console.WriteLine($"{pricelist[i].nameofprod,-20}|{pricelist[i].type,-15}|{pricelist[i].price,-10}|{pricelist[i].quantity,-10}");
                                }
                            }
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case "6":
                            Console.Clear();
                            TimeSpan longperiodinactivity = dateTimes[1].Subtract(dateTimes[0]);
                            for (int i = 0; i < datepos; i++)
                            {
                                Console.WriteLine($"{dateTimes[i].Hour}:{dateTimes[i].Minute}:{dateTimes[i].Second} - {explainer[i]}");
                                if ((dateTimes[i + 1].Subtract(dateTimes[i])) > longperiodinactivity)
                                {
                                    longperiodinactivity = dateTimes[i + 1].Subtract(dateTimes[i]);
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine($"{longperiodinactivity.Hours}:{longperiodinactivity.Minutes}:{longperiodinactivity.Seconds} - Наибольший период бездействия пользователя.");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case "7":
                            FileStream lastfile = new FileStream(@"C:\Users\USER\Desktop\Lab6\Number1(6)\lab.dat", FileMode.Open);
                            BinaryWriter biwrite = new BinaryWriter(lastfile);
                            for (int i = 0; i < pos; i++)
                            {
                                biwrite.Write(pricelist[i].nameofprod);
                                biwrite.Write(pricelist[i].type.ToString());
                                biwrite.Write(pricelist[i].price);
                                biwrite.Write(pricelist[i].quantity);
                                
                            }
                            biwrite.Close();
                            mark = false;
                                
                                    
                            break;
                        default:
                            Console.Clear();
                            break;

                    }
                }
            }
        }
    }
}
