using System;
using System.Collections.Generic;
using System.Threading;
using System.Collections.Concurrent;

//class Program
//{
//    static void Main(string[] args)
//    {
//        Bank bank = new Bank(1000);
//        List<Thread> atmThreads = new List<Thread>();

//        for (int i = 0; i < 10; i++)
//        {
//            Thread atmThread = new Thread(() => ATM(bank));
//            atmThreads.Add(atmThread);
//            atmThread.Start();
//        }

//        foreach (Thread t in atmThreads)
//        {
//            t.Join();
//        }

//        Console.WriteLine("Все операции завершены.");
//    }

//    static void ATM(Bank bank)
//    {
//        Random rand = new Random();
//        for (int i = 0; i < 10; i++)
//        {
//            int amount = rand.Next(1, 200);
//            bank.Withdraw(amount);
//            Thread.Sleep(rand.Next(100));
//        }
//    }
//}

//class Bank
//{
//    private int _balance;
//    private readonly object _balanceLock = new object();

//    public Bank(int initialBalance)
//    {
//        _balance = initialBalance;
//    }

//    public void Withdraw(int amount)
//    {
//        bool lockTaken = false;

//        try
//        {
//            Monitor.Enter(_balanceLock, ref lockTaken);

//            if (_balance >= amount)
//            {
//                Console.WriteLine($"Снимается {amount}. Баланс до: {_balance}");
//                _balance -= amount;
//                Console.WriteLine($"Баланс после: {_balance}");
//            }
//            else
//            {
//                Console.WriteLine($"Недостаточно средств для снятия {amount}. Текущий баланс: {_balance}");
//            }
//        }
//        finally
//        {
//            if (lockTaken)
//            {
//                Monitor.Exit(_balanceLock);
//            }
//        }
//    }
//}



// доп задача


//class Program
//{
//    static void Main(string[] args)
//    {
//        int numberOfPrinters = 3;
//        int numberOfJobs = 10;
//        Semaphore semaphore = new Semaphore(numberOfPrinters, numberOfPrinters);
//        List<Thread> jobThreads = new List<Thread>();

//        for (int i = 1; i <= numberOfJobs; i++)
//        {
//            int jobNumber = i;
//            Thread jobThread = new Thread(() => PrintJob(semaphore, jobNumber));
//            jobThreads.Add(jobThread);
//            jobThread.Start();
//        }

//        foreach (Thread t in jobThreads)
//        {
//            t.Join();
//        }

//        Console.WriteLine("Все задания на печать завершены.");
//    }

//    static void PrintJob(Semaphore semaphore, int jobNumber)
//    {
//        semaphore.WaitOne();

//        try
//        {
//            Console.WriteLine("Printing job {0} on printer {1}.", jobNumber, Thread.CurrentThread.ManagedThreadId);
//            Thread.Sleep(1000);
//            Console.WriteLine("Job {0} completed on printer {1}.", jobNumber, Thread.CurrentThread.ManagedThreadId);
//        }
//        finally
//        {
//            semaphore.Release();
//        }
//    }
//}


// вторая доп задача


class Program
{
    static BlockingCollection<double> suitcase = new BlockingCollection<double>();
    static AutoResetEvent stopEvent = new AutoResetEvent(false);
    static Random random = new Random();
    static double maxWeight = 20.0;
    static double currentWeight = 0;
    static object weightLock = new object();

    static void Main(string[] args)
    {
        int numberOfItemsDad = 0;
        int numberOfItemsMom = 0;
        int numberOfItemsChild = 0;

        Thread dad = new Thread(() => AddItems("Dad", ref numberOfItemsDad));
        Thread mom = new Thread(() => AddItems("Mom", ref numberOfItemsMom));
        Thread child = new Thread(() => AddItems("Child", ref numberOfItemsChild));
        Thread server = new Thread(Server);

        dad.Start();
        mom.Start();
        child.Start();
        server.Start();

        dad.Join();
        mom.Join();
        child.Join();
        server.Join();

        Console.WriteLine("Все задания на печать завершены.");
        Console.WriteLine($"Dad packed {numberOfItemsDad} items.");
        Console.WriteLine($"Mom packed {numberOfItemsMom} items.");
        Console.WriteLine($"Child packed {numberOfItemsChild} items.");
    }

    static void AddItems(string name, ref int itemCount)
    {
        while (!stopEvent.WaitOne(0))
        {
            double itemWeight = Math.Round(random.NextDouble() * 4.4 + 0.1, 1);
            suitcase.Add(itemWeight);
            itemCount++;
            Console.WriteLine($"{name} добавил предмет весом {itemWeight} кг.");
            Thread.Sleep(100);
        }
    }

    static void Server()
    {
        foreach (var item in suitcase.GetConsumingEnumerable())
        {
            lock (weightLock)
            {
                currentWeight += item;
                if (currentWeight > maxWeight)
                {
                    Console.WriteLine("Чемодан достиг максимального веса. Остановка.");
                    stopEvent.Set();
                    break;
                }
            }
        }

        while (suitcase.Count > 0)
        {
            suitcase.Take();
        }
    }
}
