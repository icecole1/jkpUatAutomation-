using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrowserMob.Net;

namespace BowserMob.TestClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Start ProxyServer using Default Path");
            Console.WriteLine("2. Start ProxyServer using Specified Path");

            Console.WriteLine("Please enter one of the options above and press <enter>");

            var option = Console.ReadLine();

            StartProxyServer(option);
        }

        public static void StartProxyServer(string option)
        {
            switch (option)
            {
                case "1":
                    ProxyServerStart(string.Empty);
                    break;
                case "2":
                    Console.WriteLine("Please enter the full path of the ProxyServer and press <enter>");
                    var serverPath = Console.ReadLine();

                    ProxyServerStart(serverPath);
                    break;
            }
        }

        private static Server ProxyServer { get; set; }

        public static Client ProxyServerStart(string serverPath)
        {
            try
            {
                ProxyServer = serverPath == string.Empty ? new Server() : new Server(serverPath);

                ProxyServer.Start();

                return ProxyServer.CreateProxy();
            }
            catch
            {
                ProxyServer.Stop();
                ProxyServer.Start();
                return ProxyServer.CreateProxy();
            }
        }
    }
}
