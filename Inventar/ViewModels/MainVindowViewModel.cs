using FKCPObj;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
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
            bot.Send("Я готов к работе");
            GetAllDocs();
        }
        public void GetAllDocs()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpWebRequest requestToServerEndpoint =
            (HttpWebRequest)WebRequest.Create("https://172.20.88.50:54322/rk7api/v0/xmlinterface.xml");
            string fileUrl = @"./GetRefData.xml";
            requestToServerEndpoint.Method = WebRequestMethods.Http.Post;
            requestToServerEndpoint.KeepAlive = true;
            requestToServerEndpoint.Credentials = new NetworkCredential("Internet", "UeM5zP");
            MemoryStream postDataStream = new MemoryStream();
            StreamWriter postDataWriter = new StreamWriter(postDataStream);
            FileStream fileStream = new FileStream(fileUrl, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[1024];
            int bytesRead = 0;
            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                postDataStream.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();
            requestToServerEndpoint.ContentLength = postDataStream.Length;
            using (Stream s = requestToServerEndpoint.GetRequestStream())
            {
                postDataStream.WriteTo(s);
            }
            postDataStream.Close();
            WebResponse response = requestToServerEndpoint.GetResponse();
            StreamReader responseReader = new StreamReader(response.GetResponseStream());
            string replyFromServer = responseReader.ReadToEnd();

        }


    }
}
