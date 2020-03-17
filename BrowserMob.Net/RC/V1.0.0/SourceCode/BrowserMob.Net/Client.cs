using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using BrowserMob.Net.HAR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.String;

namespace BrowserMob.Net
{
    public class Client
    {
        private readonly short _port;
        private readonly string _baseUrlProxy;

        public Client(string url)
        {
            //MakeRequest($"{url}/proxy", "POST", "useEcc=true&trustAllServers=true");

            if (IsNullOrEmpty(url))
                throw new ArgumentException("url not supplied", nameof(url));

            _baseUrlProxy = $"{url}/proxy";
            var requestUrl = $"{_baseUrlProxy}?trustAllServers=true";
            using (var response = MakeRequest(requestUrl, "POST"))
            {
                var responseStream = response.GetResponseStream();
                if (responseStream == null)
                    throw new Exception("No response from proxy");

                using (var responseStreamReader = new StreamReader(responseStream))
                {
                    var jsonReader = new JsonTextReader(responseStreamReader);
                    var token = JToken.ReadFrom(jsonReader);
                    var portToken = token.SelectToken("port");
                    if (portToken == null)
                        throw new Exception("No port number returned from proxy");

                    _port = (short)portToken;
                }
            }

            var parts = url.Split(':');
            SeleniumProxy = parts[1].TrimStart('/') + ":" + _port;
        }

        public Client(string url, string upstreamProxyUrl, string username, string password)
        {
            if (IsNullOrEmpty(url))
                throw new ArgumentException("url not supplied", nameof(url));

            if (IsNullOrEmpty(upstreamProxyUrl))
                throw new ArgumentException("upstreamProxyUrl not supplied", nameof(upstreamProxyUrl));

            _baseUrlProxy = $"{url}/proxy";

            string requestUrl = $"{_baseUrlProxy}?httpProxy={upstreamProxyUrl}&trustAllServers=true";

            if (username != string.Empty && password != string.Empty)
            {
                requestUrl = string.Concat(requestUrl, $"&proxyUsername={username}&proxyPassword={password}");
            }

            using (var response = MakeRequest(requestUrl, "POST"))
            {
                var responseStream = response.GetResponseStream();
                if (responseStream == null)
                    throw new Exception("No response from proxy");

                using (var responseStreamReader = new StreamReader(responseStream))
                {
                    var jsonReader = new JsonTextReader(responseStreamReader);
                    var token = JToken.ReadFrom(jsonReader);
                    var portToken = token.SelectToken("port");
                    if (portToken == null)
                        throw new Exception("No port number returned from proxy");

                    _port = (short)portToken;
                }
            }

            var parts = url.Split(':');
            SeleniumProxy = parts[1].TrimStart('/') + ":" + _port;
        }

        public void NewHar(string reference = null)
        {
            MakeRequest($"{_baseUrlProxy}/{_port}/har", "PUT", reference);
        }

        private static WebResponse MakeRequest(string url, string method, string reference = null)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            if (reference != null)
            {
                var requestBytes = Encoding.UTF8.GetBytes(reference);
                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(requestBytes, 0, requestBytes.Length);
                    requestStream.Close();
                }

                request.ContentType = "application/x-www-form-urlencoded";
            }
            else
                request.ContentLength = 0;

            return request.GetResponse();
        }

        private static WebResponse MakeJsonRequest(string url, string method, string payload)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;

            if (payload != null)
            {
                request.ContentType = "text/json";
                request.ContentLength = payload.Length;
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(payload);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
            else
                request.ContentLength = 0;

            return request.GetResponse();
        }

        public void NewPage(string reference)
        {
            MakeRequest($"{_baseUrlProxy}/{_port}/har/pageRef", "PUT", reference);
        }

        public HarResult GetHar()
        {
            var response = MakeRequest($"{_baseUrlProxy}/{_port}/har", "GET");
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream == null)
                    return null;

                using (var responseStreamReader = new StreamReader(responseStream))
                {
                    var json = responseStreamReader.ReadToEnd();
                    return JsonConvert.DeserializeObject<HarResult>(json);
                }
            }
        }

        public void SetLimits(LimitOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options), "LimitOptions must be supplied");

            MakeRequest($"{_baseUrlProxy}/{_port}/limit", "PUT", options.ToFormData());
        }

        public string SeleniumProxy { get; }

        public void WhiteList(string regexp, int statusCode)
        {
            var data = FormatBlackOrWhiteListFormData(regexp, statusCode);
            MakeRequest($"{_baseUrlProxy}/{_port}/whitelist", "PUT", data);
        }

        public void Blacklist(string regexp, int statusCode)
        {
            var data = FormatBlackOrWhiteListFormData(regexp, statusCode);
            MakeRequest($"{_baseUrlProxy}/{_port}/blacklist", "PUT", data);
        }

        public void SetHeader(string name, string value)
        {
            var header = @"{ """ + name + @""":""" + value + @""" }";

            MakeJsonRequest($"{_baseUrlProxy}/{_port}/headers", "POST", header);
        }

        public void RemapHost(string host, string ipAddress)
        {
            MakeJsonRequest($"{_baseUrlProxy}/{_port}/hosts", "POST", "{\"" + host + "\":\"" + ipAddress + "\"}");
        }

        private static string FormatBlackOrWhiteListFormData(string regexp, int statusCode)
        {
            return $"regex={HttpUtility.UrlEncode(regexp)}&status={statusCode}";
        }

        /// <summary>
        /// shuts down the proxy and closes the port
        /// </summary>
        public void Close()
        {
            MakeRequest($"{_baseUrlProxy}/{_port}", "DELETE");
        }
    }

}