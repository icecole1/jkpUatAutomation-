using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace BrowserMob.Net
{
    public class Server
    {
        private Process _serverProcess;
        private readonly int _port;
        private readonly string _path;
        private const string Host = "localhost";

        public Server() : this(string.Empty, 8080)
        {  
        }

        public Server(string path) : this(path, 8080)
        { }

        public Server(string path, int port)
        {
            _path = string.IsNullOrEmpty(_path) ? GetDefaultServerPath() : path;

            _port = port;
        }

        private string GetDefaultServerPath()
        {
            var binPath = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory);
            var serverProxyPath = Path.GetFullPath(Path.Combine(binPath, @"..\..\browsermob-proxy-2.1.4\bin\browsermob-proxy.bat"));

            return serverProxyPath;
        }

        public void Start()
        {
            _serverProcess = new Process
            {
                StartInfo = { FileName = _path }
            };
            if (_port != 0)
            {
                _serverProcess.StartInfo.Arguments = $"--port={_port}";
            }

            try
            {
                _serverProcess.Start();
                int count = 0;
                while (!IsListening())
                {
                    Thread.Sleep(1000);
                    count++;
                    if (count == 30)
                    {
                        throw new Exception("Can not connect to BrowserMob Proxy");
                    }
                }
            }
            catch
            {
                _serverProcess.Dispose();
                _serverProcess = null;
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Stop()
        {
            if (_serverProcess != null && !_serverProcess.HasExited)
            {
                _serverProcess.CloseMainWindow();
                _serverProcess.Dispose();
                _serverProcess = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Client CreateProxy()
        {
            return new Client(Url);
        }

        public Client CreateProxy(string upstreamProxyUrl, string username = "", string password = "")
        {
            return new Client(Url, upstreamProxyUrl, username, password);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Url => $"http://{Host}:{_port.ToString(CultureInfo.InvariantCulture)}";

        /// <summary>
        /// 
        /// </summary>
        private bool IsListening()
        {
            try
            {
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(Host, _port);
                socket.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}