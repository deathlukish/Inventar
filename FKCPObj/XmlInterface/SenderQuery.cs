using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace FKCPObj.XmlInterface
{
    internal static class SenderQuery
    {
        private static string resultXML = "";
        private static string XmlQuery = "";
        /// <summary>
        /// Получить результат команды из XML интерфейсе
        /// </summary>
        /// <param name="xmlQuery">
        /// XML файл команды
        /// </param>
        /// <returns>
        /// Файл XML ответа из интерфейса
        /// </returns>
        public static string GetResultXML(XmlQueryCreater xmlQuery)
        {
            XmlQuery = xmlQuery.ToString();           
            Task task = Task.Run(LoadRefAsync);
            try
            {
                task.Wait();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
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
 
    }
}
