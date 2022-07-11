using FKCPObj.SimpleClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FKCPObj.XmlInterface
{
    internal static class SenderQuery
    {
        private static string resultXML = "";
        private static string XmlQuery = "";
        public static string GetResultXML(RefNames refNames)
        {
            GetXMLQuery(refNames.ToString());            
            Task task = Task.Run(LoadRefAsync);
            task.Wait();
            return resultXML;
        }
                
        /// <summary>
        /// Отправка запроса на сервер и получения результата в виде XML
        /// </summary>
        private static async Task LoadRefAsync()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            string? userName = ConfigLoad.GetConfig()?.XMLInterface?.Login;
            string? passwd = ConfigLoad.GetConfig()?.XMLInterface?.Password;
            byte[] authToken = Encoding.ASCII.GetBytes($"{userName}:{passwd}");
            string? url = ConfigLoad.GetConfig()?.XMLInterface?.ServerURL;
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            using (var client = new HttpClient(httpClientHandler))
            {
                using (var multipartFormContent = new MultipartFormDataContent())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));
                    var reqestXML = new StringContent(XmlQuery);
                    multipartFormContent.Add(reqestXML);
                    var response = await client.PostAsync(url, multipartFormContent);
                    try
                    {
                        response.EnsureSuccessStatusCode();
                        resultXML = await response.Content.ReadAsStringAsync();
                    }
                    catch (Exception ex)
                    {
                        //Where event
                        //MessageBox.Show($"Уппс {ex.ToString}");
                    }

                }
            }
 
        }
        /// <summary>
        /// Метод формироания XML-запроса для сервера
        /// </summary>
        /// <param name="RefName">
        /// Имя справочника в коллекции справочников сервера
        /// </param>
        /// <param name="items">
        /// Список атрибутов для фильтрации на стороне сервера
        /// Без атрибутов - без фильтрации
        /// </param>
        /// <returns>
        /// XDocument готовый для отправки на сервер
        /// </returns>
        private static void GetXMLQuery(string RefName, params string[] items)
        {
            XDocument xmlQuery = new XDocument(
            new XElement("RK7Query",
                    new XElement("RK7Command2",
                    new XAttribute("CMD", "GetRefData"),
                    new XAttribute("RefName", RefName)))

            );
            if (items.Length != 0)
            {
                StringBuilder Prop = new StringBuilder();
                Prop.AppendJoin(",", items);
                xmlQuery.Element("RK7Query")?
                        .Element("RK7Command2")?
                        .Add(new XAttribute("PropMask", $"items.({Prop})"));

            }
            XmlQuery = xmlQuery.ToString();
        }

    }
}
