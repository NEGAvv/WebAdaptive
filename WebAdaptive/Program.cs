using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // 1. System.IO
        string filePath = "example.txt";
        WriteToFile(filePath, "Hello, .NET Standard!");
        string content = ReadFromFile(filePath);

        Console.WriteLine($"Content read from file: {content}");

        // 2. System.Net.Http
        string url = "https://github.com/NEGAvv/WebAdaptive";
        string webContent = await DownloadContentAsync(url);

        Console.WriteLine($"Content from {url}:\n{webContent}");

        // 3. System.Linq
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
        var squaredNumbers = numbers.Select(n => n * n);

        Console.WriteLine("Squared numbers:");
        foreach (var num in squaredNumbers)
        {
            Console.WriteLine(num);
        }

        // 4. System.Threading.Tasks
        Console.WriteLine("Start");
        await DoSomethingAsync();
        Console.WriteLine("End");

        // 5. System.Text.Json
        var person = new Person { Name = "Alina", Age = 19 };
        string jsonString = SerializeToJson(person);

        Console.WriteLine($"JSON representation:\n{jsonString}");
    }

    // 1. System.IO
    static void WriteToFile(string filePath, string content)
    {
        File.WriteAllText(filePath, content);
        Console.WriteLine($"Content written to {filePath}");
    }

    static string ReadFromFile(string filePath)
    {
        return File.ReadAllText(filePath);
    }

    // 2. System.Net.Http
    static async Task<string> DownloadContentAsync(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            return await client.GetStringAsync(url);
        }
    }

    // 4. System.Threading.Tasks
    static async Task DoSomethingAsync()
    {
        await Task.Delay(2000);
        Console.WriteLine("Task completed after 2 seconds");
    }

    // 5. System.Text.Json
    static string SerializeToJson<T>(T obj)
    {
        return JsonSerializer.Serialize(obj);
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
