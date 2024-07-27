using System;
using Microsoft.Win32;

//namespace ConsoleApp
//{
//    class Program
//    {
//        private const string registryKeyPath = @"SOFTWARE\MyApp";
//        private const string registryValueName = "LastAccess";

//        static void Main(string[] args)
//        {
//            WriteLastAccessTimeToRegistry();

//            DateTime? lastAccessTime = ReadLastAccessTimeFromRegistry();
//            if (lastAccessTime.HasValue)
//            {
//                Console.WriteLine($"Последний доступ: {lastAccessTime.Value}");
//            }
//            else
//            {
//                Console.WriteLine("Информация о последнем доступе отсутствует.");
//            }

//            Console.WriteLine("Нажмите любую клавишу для выхода...");
//            Console.ReadKey();
//        }

//        static void WriteLastAccessTimeToRegistry()
//        {
//            try
//            {
//                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(registryKeyPath))
//                {
//                    if (key != null)
//                    {
//                        key.SetValue(registryValueName, DateTime.Now.ToString());
//                        Console.WriteLine("Дата и время последнего доступа записаны в реестр.");
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Ошибка при записи в реестр: {ex.Message}");
//            }
//        }

//        static DateTime? ReadLastAccessTimeFromRegistry()
//        {
//            try
//            {
//                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryKeyPath))
//                {
//                    if (key != null)
//                    {
//                        object value = key.GetValue(registryValueName);
//                        if (value != null && DateTime.TryParse(value.ToString(), out DateTime lastAccessTime))
//                        {
//                            return lastAccessTime;
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Ошибка при чтении из реестра: {ex.Message}");
//            }

//            return null;
//        }
//    }
//}



// вторая доп задача



//class Program
//{
//    static void Main(string[] args)
//    {
//        Random random = new Random();
//        int var1 = random.Next();
//        int var2 = random.Next();
//        int var3 = 0;

//        var3 = (int)((uint)var1 & 0xFFFF0000) | (int)(((uint)var2 >> 16) & 0x0000FFFF);

//        Console.WriteLine("Первое случайное значение: {0} (0x{0:X8})", var1);
//        Console.WriteLine("Второе случайное значение: {0} (0x{0:X8})", var2);
//        Console.WriteLine("Результирующее значение: {0} (0x{0:X8})", var3);

//        byte[] bytesVar1 = BitConverter.GetBytes(var1);
//        byte[] bytesVar2 = BitConverter.GetBytes(var2);
//        byte[] bytesVar3 = BitConverter.GetBytes(var3);

//        Console.WriteLine("Байты первой переменной: {0:X2} {1:X2} {2:X2} {3:X2}", bytesVar1[0], bytesVar1[1], bytesVar1[2], bytesVar1[3]);
//        Console.WriteLine("Байты второй переменной: {0:X2} {1:X2} {2:X2} {3:X2}", bytesVar2[0], bytesVar2[1], bytesVar2[2], bytesVar2[3]);
//        Console.WriteLine("Байты третьей переменной: {0:X2} {1:X2} {2:X2} {3:X2}", bytesVar3[0], bytesVar3[1], bytesVar3[2], bytesVar3[3]);

//        Console.WriteLine("Проверка корректности:");
//        Console.WriteLine("{0:X2} {1:X2} == {2:X2} {3:X2}", bytesVar3[0], bytesVar3[1], bytesVar1[0], bytesVar1[1]);
//        Console.WriteLine("{0:X2} {1:X2} == {2:X2} {3:X2}", bytesVar3[2], bytesVar3[3], bytesVar2[2], bytesVar2[3]);
//    }
//}



