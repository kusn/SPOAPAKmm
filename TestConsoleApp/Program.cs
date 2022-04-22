using System;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using TestConsoleApp.Configurations;

namespace TestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string hostUrl = "http://localhost:8080/";

            using (WebApp.Start<Startup>(hostUrl))
            {
                Console.WriteLine($"Сервер запущен по следующему адресу: {hostUrl}");
                Console.ReadLine();
            }
        }
    }
}
