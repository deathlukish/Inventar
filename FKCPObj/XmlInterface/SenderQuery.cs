﻿using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace FKCPObj.XmlInterface
{
    internal static class SenderQuery
    {
        private static string _resultXML = "";
        private static string _xmlQuery = "";
        /// <summary>
        /// Получить результат команды из XML интерфейсе
        /// </summary>
        /// <param name="xmlQuery">
        /// XML файл команды
        /// </param>
        /// <returns>
        /// Файл XML ответа из интерфейса
        /// </returns>
        public static async Task<string> GetResultXML(XmlQueryBuilder xmlQuery)
        {
            _xmlQuery = xmlQuery.ToString();
            _resultXML = await LoadRefAsync();
            return _resultXML;
        

        /// <summary>
        /// Отправка запроса на сервер и получения результата в виде XML
        /// </summary>
            static async Task<string> LoadRefAsync()
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
                try
                {
                    using (var client = new HttpClient(httpClientHandler))
                    {
                        using (var multipartFormContent = new MultipartFormDataContent())
                        {
                            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));
                            var reqestXML = new StringContent(_xmlQuery);
                            multipartFormContent.Add(reqestXML);
                            var response = await client.PostAsync(url, multipartFormContent);
                            response.EnsureSuccessStatusCode();
                            _resultXML = await response.Content.ReadAsStringAsync();

                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Уппс {ex.Message}");
                }
                return _resultXML;
            }
        }

    }
}
