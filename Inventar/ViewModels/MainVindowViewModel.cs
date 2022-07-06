using FKCPObj;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;
using System.Xml.Linq;
using Telegram.Bot.Types;
using TelegramBotPolling;
using TelegramPolling;

namespace Inventar.ViewModels
{
    internal class MainVindowViewModel:ViewModel
    {

        public MainVindowViewModel()
        {
            BotInit bot = new BotInit(ConfigLoad.LoadConfig().ApiToken!.Token!);
            UpdateHandlers.Update += (Message a)=>MessageBox.Show(a.From.ToString());

            GetRef();
            //RetXML();
        }
        /// <summary>
        /// Отправка запроса на сервер и получения результата в виде XML
        /// </summary>
        public async void GetRef()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            string userName = "Internet";
            string passwd = "UeM5zP";
            byte[] authToken = Encoding.ASCII.GetBytes($"{userName}:{passwd}");
            string filePath = @"./GetRefData.xml";
            string url = "https://172.20.88.50:54322/rk7api/v0/xmlinterface.xml";
            string resultXML;
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            using (var client = new HttpClient(httpClientHandler))
            {
                using (var multipartFormContent = new MultipartFormDataContent())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));
                   // var fileStreamContent = new StreamContent(System.IO.File.OpenRead(filePath));
                    var reqestXML = new StringContent(GetXMLQuery().ToString());
                    multipartFormContent.Add(reqestXML);
                    var response = await client.PostAsync(url, multipartFormContent);
                    response.EnsureSuccessStatusCode();
                    resultXML = await response.Content.ReadAsStringAsync();

                }
            }
        }
        /// <summary>
        /// Метод формирования XML запроса
        /// </summary>
        /// <returns></returns>
        public XDocument GetXMLQuery()
        {            
            string items = "items.(Code, AltName, DeviceLicenses)";
            //создаем структуру XML-файла
            XDocument xmlQuery = new XDocument(
            new XElement("RK7Query", 
                    new XElement("RK7Command2", 
                    new XAttribute("CMD", "GetRefData"),
                    new XAttribute("RefName", "RESTAURANTS"),
                    new XAttribute("PropMask", items)))
            );
           return xmlQuery;

        }

    }
}
