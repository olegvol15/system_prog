using System;
using System.Collections.Concurrent;
using System.Threading;

//class Program
//{
//    static void Main(string[] args)
//    {
//        int numberOfCashRegisters = 3;
//        int numberOfCustomers = 20;
//        Random random = new Random();

//        ConcurrentQueue<Customer> customerQueue = new ConcurrentQueue<Customer>();
//        for (int i = 1; i <= numberOfCustomers; i++)
//        {
//            customerQueue.Enqueue(new Customer { Id = i });
//        }

//        Thread[] cashRegisterThreads = new Thread[numberOfCashRegisters];
//        for (int i = 0; i < numberOfCashRegisters; i++)
//        {
//            CashRegister cashRegister = new CashRegister(i + 1, customerQueue, random);
//            cashRegisterThreads[i] = new Thread(new ThreadStart(cashRegister.ProcessCustomers));
//            cashRegisterThreads[i].Start();
//        }

//        foreach (Thread thread in cashRegisterThreads)
//        {
//            thread.Join();
//        }

//        Console.WriteLine("Все покупатели обслужены.");
//    }
//}

//class Customer
//{
//    public int Id { get; set; }
//}

//class CashRegister
//{
//    private int Id { get; }
//    private ConcurrentQueue<Customer> CustomerQueue { get; }
//    private Random Random { get; }

//    public CashRegister(int id, ConcurrentQueue<Customer> customerQueue, Random random)
//    {
//        Id = id;
//        CustomerQueue = customerQueue;
//        Random = random;
//    }

//    public void ProcessCustomers()
//    {
//        while (CustomerQueue.TryDequeue(out Customer customer))
//        {
//            Console.WriteLine($"Касса {Id}: Покупатель {customer.Id} начинает обслуживание.");
//            int serviceTime = Random.Next(1, 4) * 1000;
//            Thread.Sleep(serviceTime);
//            Console.WriteLine($"Касса {Id}: Покупатель {customer.Id} заканчивает обслуживание (время: {serviceTime / 1000} секунд).");
//        }
//    }
//}



// доп задача


//class Program
//{
//    static void Main(string[] args)
//    {
//        int numberOfClients = 5;
//        List<Client> clients = new List<Client>();
//        List<Thread> clientThreads = new List<Thread>();
//        Random random = new Random();

//        for (int i = 1; i <= numberOfClients; i++)
//        {
//            Account account = new Account { Balance = 1000 };
//            Client client = new Client(i, account, random);
//            clients.Add(client);

//            Thread clientThread = new Thread(new ThreadStart(client.PerformOperations));
//            clientThreads.Add(clientThread);
//            clientThread.Start();
//        }

//        Thread.Sleep(30000);

//        foreach (Client client in clients)
//        {
//            client.Stop();
//        }

//        foreach (Thread thread in clientThreads)
//        {
//            thread.Join();
//        }

//        Console.WriteLine("Программа завершена. Итоговое состояние счетов:");
//        foreach (Client client in clients)
//        {
//            Console.WriteLine($"Клиент {client.Id}: Баланс {client.Account.Balance}");
//        }
//    }
//}

//class Account
//{
//    private decimal balance;
//    private object balanceLock = new object();

//    public decimal Balance
//    {
//        get
//        {
//            lock (balanceLock)
//            {
//                return balance;
//            }
//        }
//        set
//        {
//            lock (balanceLock)
//            {
//                balance = value;
//            }
//        }
//    }

//    public void Deposit(decimal amount)
//    {
//        lock (balanceLock)
//        {
//            balance += amount;
//        }
//    }

//    public bool Withdraw(decimal amount)
//    {
//        lock (balanceLock)
//        {
//            if (balance >= amount)
//            {
//                balance -= amount;
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }
//    }
//}

//class Client
//{
//    public int Id { get; }
//    public Account Account { get; }
//    private Random Random { get; }
//    private bool running;

//    public Client(int id, Account account, Random random)
//    {
//        Id = id;
//        Account = account;
//        Random = random;
//        running = true;
//    }

//    public void Stop()
//    {
//        running = false;
//    }

//    public void PerformOperations()
//    {
//        while (running)
//        {
//            int operation = Random.Next(0, 2);
//            decimal amount = Random.Next(1, 101);

//            if (operation == 0)
//            {
//                Account.Deposit(amount);
//                Console.WriteLine($"Клиент {Id}: Пополнение на сумму {amount}. Текущий баланс: {Account.Balance}");
//            }
//            else
//            {
//                if (Account.Withdraw(amount))
//                {
//                    Console.WriteLine($"Клиент {Id}: Снятие на сумму {amount}. Текущий баланс: {Account.Balance}");
//                }
//                else
//                {
//                    Console.WriteLine($"Клиент {Id}: Недостаточно средств для снятия {amount}. Текущий баланс: {Account.Balance}");
//                }
//            }

//            Thread.Sleep(Random.Next(1000, 3000));
//        }
//    }
//}
