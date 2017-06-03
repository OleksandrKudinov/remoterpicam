using System;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Hosting;

namespace RRPiCam.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            IPProvider.ShowIP();
            var host = new WebHostBuilder()
                .UseUrls("http://0.0.0.0:33333")
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }

    public class IPProvider
    {
        public static void ShowIP()
        {
            Console.WriteLine("-------------------------");
            var strHostName = Dns.GetHostName();
            Console.WriteLine($"Host Name: {strHostName}");
            foreach (IPAddress address in Dns.GetHostAddresses(strHostName))
            {
                Console.WriteLine(address);
            }
            Console.WriteLine("-------------------------");
        }
    }
}
