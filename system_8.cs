using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

//namespace FileReadWrite
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string filePath = "text.txt";
//            string textToWrite = "Это пример текста для сохранения в файл.";

//            File.WriteAllText(filePath, textToWrite);
//            Console.WriteLine("Текст записан в файл.");

//            string textFromFile = File.ReadAllText(filePath);
//            Console.WriteLine("Текст, прочитанный из файла:");
//            Console.WriteLine(textFromFile);

//            Console.WriteLine("Нажмите любую клавишу для выхода...");
//            Console.ReadKey();
//        }
//    }
//}



//доп задача

//namespace AsyncDataLoading
//{
//    class Program
//    {
//        static async Task Main(string[] args)
//        {
//            try
//            {
//                var userData = await LoadUserDataAsync();
//                Console.WriteLine("Данные пользователя загружены:");
//                Console.WriteLine(userData);
//            }
//            catch (OperationCanceledException)
//            {
//                Console.WriteLine("Запрос к серверу был отменен из-за превышения времени ожидания.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Произошла ошибка при загрузке данных: {ex.Message}");
//            }
//            Console.WriteLine("Нажмите любую клавишу для выхода...");
//            Console.ReadKey();
//        }

//        static async Task<string> LoadUserDataAsync()
//        {
//            using (var httpClient = new HttpClient())
//            using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10)))
//            {
//                try
//                {
//                    // Симуляция зависания сервера
//                    var response = await httpClient.GetAsync("https://httpstat.us/200?sleep=15000", cts.Token);
//                    response.EnsureSuccessStatusCode();
//                    return await response.Content.ReadAsStringAsync();
//                }
//                catch (TaskCanceledException)
//                {
//                    if (cts.Token.IsCancellationRequested)
//                    {
//                        throw new OperationCanceledException("Запрос был отменен.");
//                    }
//                    throw;
//                }
//            }
//        }
//    }
//}

