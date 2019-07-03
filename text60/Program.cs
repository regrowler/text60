using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace text60
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя файла");
            String file1 = Console.ReadLine();
            Console.WriteLine("Введите расшифрованную первую строку");
            String firstline = Console.ReadLine();
            if (firstline.Length < 10)
            {
                Console.WriteLine("недостаточно данных");
                Console.ReadLine();
               // return;
            }
            ArrayList s=new ArrayList();
            try
            {
                FileStream file=new FileStream(file1+".txt",FileMode.Open);
                StreamReader streamReader=new StreamReader(file);
                String liner = streamReader.ReadLine();
                Console.WriteLine("Текст:");
                while (liner != null)
                {
                    Console.WriteLine(liner);
                    s.Add(liner);
                    liner = streamReader.ReadLine();
                    
                    
                }
                //Console.ReadLine();
                liner = (string)s[0];
                if (liner.Length != firstline.Length)
                {
                    Console.WriteLine("Длина расшифрованной строки не совпадает с исходной");
                    Console.ReadLine();
                    return;
                }

                int[] mas = new int[10];
                for (int j = 0; j < mas.Length; j++)
                {
                    mas[j]=Int32.MinValue;
                }
                for (int i = 0; i < liner.Length; i++)
                {
                    //Console.WriteLine((int)liner[0]);
                    if (liner[i] >= 1072 & liner[i] <= 1103)
                    {
                        if (firstline[i] >= 1072 & firstline[i] <= 1103)
                        {
                            int j = liner[i] - firstline[i];
                            while (j<-32|j>=32)
                            {
                                if (j < 0) {j += 32;}
                                else if(j>=32)
                                {
                                    j -= 32;
                                }
                            }

                            mas[i % 10] = j;
                        }
                        else
                        {
                            Console.WriteLine("Строка расшифрована неправильно");
                            Console.ReadLine();
                            // return;
                        }
                    }
                    else if (liner[i] >= 1040 & liner[i] <= 1071)
                    {
                        if (firstline[i] >= 1040 & firstline[i] <= 1071)
                        {
                            int j = liner[i] - firstline[i];
                            while ((j < -32 )| j >= 32)
                            {
                                if (j < 0)
                                {
                                    if (j < -32)
                                    {
                                        j += 32;
                                    }

                                }
                                else if (j >= 32)
                                {
                                    j -= 32;
                                }
                            }

                            mas[i % 10] = j;
                            
                        }

                    }
                    
                }
                for (int u = 0; u < mas.Length; u++)
                {
                    if (mas[u] == Int32.MinValue)
                    {
                        Console.WriteLine("недостаточно данных");
                        //Console.ReadLine();
                        Console.ReadKey();
                        return;
                    }
                    Console.Write(mas[u]+" ");

                }
                Console.ReadLine();
                StringBuilder builder =new StringBuilder();
                builder.AppendLine(firstline);
                for (int i = 1; i < s.Count; i++)
                {
                    string ss = (string) s[i];
                    StringBuilder b=new StringBuilder();
                    for (int j = 0; j < ss.Length; j++)
                    {
                        if (ss[i] >= 1072 & ss[i] <= 1103)
                        {
                            int c = ss[i] + mas[j % 10];
                            if (c < 1072)
                            {
                                c += 32;
                            }else if (c > 1103)
                            {
                                c -= 32;
                            }

                            b.Append((char)c);
                        }
                        else if (ss[i] >= 1040 & ss[i] <= 1071)
                        {
                            int c = ss[i] + mas[j % 10];
                            if (c < 1040)
                            {
                                c += 32;
                            }
                            else if (c > 1071)
                            {
                                c -= 32;
                            }
                            b.Append((char)c);
                        }
                        else
                        {
                            b.Append((char)ss[i]);
                        }
                    }
                    builder.AppendLine(b.ToString());
                }
                Console.WriteLine("Расшифрованный текст:");
                Console.WriteLine(builder.ToString());
                streamReader.Close();
                file.Close();
                file=new FileStream(file1+".txt",FileMode.Create);
                StreamWriter writer=new StreamWriter(file);
                writer.Write(builder.ToString());
                writer.Close();
                file.Close();
                Console.ReadKey();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                //throw;
            }
        }
    }
}
