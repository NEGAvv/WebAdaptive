using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
        static void Main(string[] args)
    {
        ThreadingDemo();
        AsyncAwaitDemo();
        GetQuoteAsync();
    }


    static void ThreadingDemo()
    {
        Console.WriteLine("ThreadingDemo started");

        Thread thread1 = new Thread(new ThreadStart(ThreadMethod1));
        Thread thread2 = new Thread(new ThreadStart(ThreadMethod2));
        thread1.Start();
        thread2.Start();
    
        Console.WriteLine("ThreadingDemo completed");
    }

    static void ThreadMethod1()
    {
        Console.WriteLine("Thread1 started");
        Thread.Sleep(4000);
        Console.WriteLine("Thread1 finished");
    }

    static void ThreadMethod2()
    {
        Console.WriteLine("Thread2 started");
        Thread.Sleep(5000);
        Console.WriteLine("Thread2 finished");
    }


    static async void AsyncAwaitDemo()
    {
        Console.WriteLine("AsyncAwaitDemo started");
        int result = 0;
        await Task.Run(() =>
        {
            Console.WriteLine("Started first async op");
            Thread.Sleep(3000);
            for (int i = 1; i <= 5; i++)
            {
                result += i * i;
            }
            Console.WriteLine($"Result: {result}");
            Console.WriteLine("Finished first async op");
        });

        result = 0;

        await Task.Run(() =>
        {
            Console.WriteLine("Started second async op");
            Thread.Sleep(4000);
            for (int i = 1; i <= 5; i++)
            {
                result = i * i;
                Console.WriteLine(result);
            }
            Console.WriteLine("Finished second async op");
        });

        Console.WriteLine("AsyncAwaitDemo completed");
    }

    static async void GetQuoteAsync()
    {
        Console.WriteLine("GetQuoteAsync started");
        HttpClient client = new HttpClient();
        string apiURL = "https://api.quotable.io/random";
        string data = await client.GetStringAsync(apiURL);
        Console.WriteLine($"Data from GetQuoteAsync: {data}");
        Console.WriteLine("GetQuoteAsync completed");
       
    }
}
