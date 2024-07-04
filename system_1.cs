using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

//class Program
//{
//    static async Task Main(string[] args)
//    {
//        string url = "https://example.com/largefile.zip";
//        string filePath = "largefile.zip";

//        Console.WriteLine("Начинается скачивание файла...");

//        await DownloadFileAsync(url, filePath);

//        Console.WriteLine("Скачивание завершено.");
//    }

//    static async Task DownloadFileAsync(string url, string filePath)
//    {
//        using (HttpClient client = new HttpClient())
//        {
//            using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
//            {
//                response.EnsureSuccessStatusCode();

//                var totalBytes = response.Content.Headers.ContentLength;

//                using (var contentStream = await response.Content.ReadAsStreamAsync())
//                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
//                {
//                    var totalRead = 0L;
//                    var buffer = new byte[8192];
//                    var isMoreToRead = true;

//                    do
//                    {
//                        var read = await contentStream.ReadAsync(buffer, 0, buffer.Length);
//                        if (read == 0)
//                        {
//                            isMoreToRead = false;
//                        }
//                        else
//                        {
//                            await fileStream.WriteAsync(buffer, 0, read);
//                            totalRead += read;

//                            Console.WriteLine($"Скачано {totalRead} из {totalBytes} байт. {((double)totalRead / totalBytes.Value * 100):0.00}% завершено.");
//                        }
//                    }
//                    while (isMoreToRead);
//                }
//            }
//        }
//    }
//}



// доп задача


//class Program
//{
//    static void Main(string[] args)
//    {
//        int[] numbers = Enumerable.Range(1, 1000000).OrderByDescending(x => x).ToArray();
//        Console.WriteLine("Начинается сортировка...");
//        var sortedNumbers = MergeSort(numbers);
//        Console.WriteLine("Сортировка завершена.");
//        Console.WriteLine(string.Join(", ", sortedNumbers.Take(10)));
//    }

//    public static int[] MergeSort(int[] array)
//    {
//        if (array.Length <= 1)
//            return array;

//        int middle = array.Length / 2;
//        int[] left = array.Take(middle).ToArray();
//        int[] right = array.Skip(middle).ToArray();

//        Task<int[]> leftTask = Task.Run(() => MergeSort(left));
//        Task<int[]> rightTask = Task.Run(() => MergeSort(right));
//        Task.WaitAll(leftTask, rightTask);

//        return Merge(leftTask.Result, rightTask.Result);
//    }

//    public static int[] Merge(int[] left, int[] right)
//    {
//        int[] result = new int[left.Length + right.Length];
//        int leftIndex = 0, rightIndex = 0, resultIndex = 0;

//        while (leftIndex < left.Length && rightIndex < right.Length)
//        {
//            if (left[leftIndex] <= right[rightIndex])
//            {
//                result[resultIndex++] = left[leftIndex++];
//            }
//            else
//            {
//                result[resultIndex++] = right[rightIndex++];
//            }
//        }

//        while (leftIndex < left.Length)
//        {
//            result[resultIndex++] = left[leftIndex++];
//        }

//        while (rightIndex < right.Length)
//        {
//            result[resultIndex++] = right[rightIndex++];
//        }

//        return result;
//    }
//}


// доп задача 2


//class Program
//{
//    static void Main(string[] args)
//    {
//        int[] numbers = Enumerable.Range(1, 100).ToArray();
//        int numberOfThreads = Math.Max(1, numbers.Length / 10);

//        Console.WriteLine($"Использование {numberOfThreads} потоков для подсчета суммы элементов массива.");

//        int totalSum = CalculateSum(numbers, numberOfThreads);

//        Console.WriteLine($"Итоговая сумма: {totalSum}");
//    }

//    static int CalculateSum(int[] array, int numberOfThreads)
//    {
//        int segmentLength = array.Length / numberOfThreads;
//        Task<int>[] tasks = new Task<int>[numberOfThreads];

//        for (int i = 0; i < numberOfThreads; i++)
//        {
//            int start = i * segmentLength;
//            int end = (i == numberOfThreads - 1) ? array.Length : start + segmentLength;

//            tasks[i] = Task.Run(() => SumSegment(array, start, end));
//        }

//        Task.WaitAll(tasks);

//        int totalSum = tasks.Sum(task => task.Result);
//        return totalSum;
//    }

//    static int SumSegment(int[] array, int start, int end)
//    {
//        int sum = 0;
//        for (int i = start; i < end; i++)
//        {
//            sum += array[i];
//        }
//        return sum;
//    }
//}
