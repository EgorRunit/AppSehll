using Ovotan.ApplicationShell.Controls;
using Ovotan.Controls.Docking.Enums;
using Ovotan.Controls.Docking.Windows;
using Ovotan.Shell.RabbitMQ.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Threading.Tasks;
using Ovotan.Shell.RabbitMQ.Api;
using Ovotan.Controls.Docking;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace AppShell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainShallManagement.AutoStartShell = new RabbitMQEndPoint();
 
            try
            {
                //RabbitMQApiHttpClient rabbitHttpClient = null;
                //var task =  Task.Run(async () =>
                //{
                //    rabbitHttpClient = await RabbitMQApiHttpClient.Connect("guest", "guest", "http://localhost:15672");
                //    var ssfdf = await rabbitHttpClient.ConnectionApi.GetConnections();
                //});
                //task.Wait();


                //// Set MQ server credentials
                //NetworkCredential networkCredential = new NetworkCredential("guest", "guest");

                //// Instantiate HttpClientHandler, passing in the NetworkCredential
                //HttpClientHandler httpClientHandler = new HttpClientHandler { Credentials = networkCredential };

                //// Instantiate HttpClient passing in the HttpClientHandler
                //using HttpClient httpClient = new HttpClient(httpClientHandler);

                //// Get the response from the API endpoint.
                //HttpResponseMessage httpResponseMessage =  httpClient.GetAsync("http://localhost:15672/api/queues/").Result;

                //// Get the response content.
                //HttpContent httpContent = httpResponseMessage.Content;

                //// Get the stream of the content.
                //using StreamReader streamReader = new StreamReader( httpContent.ReadAsStreamAsync().Result);

                //// Get the output string.
                //string returnedJsonString = streamReader.ReadToEndAsync().Result;

                //// Instantiate a list to loop through.
                //List<string> mqAccountNames = new List<string>();

                //if (returnedJsonString != "")
                //{
                //    // Deserialize into object
                //    //dynamic dynamicJson = JsonConvert.DeserializeObject(returnedJsonString);
                //    //if (dynamicJson != null)
                //    //{
                //    //    foreach (dynamic item in dynamicJson)
                //    //    {
                //    //        mqAccountNames.Add(item.name.ToString());
                //    //    }
                //    //}
                //}

                //bool accountExists = false;

                //foreach (string mqAccountName in mqAccountNames)
                //{
                //    if (mqAccountName == "fff")
                //    {
                //        accountExists = true;
                //    }
                //}

                ////switch (accountExists)
                ////{
                ////    case true:
                ////        Console.WriteLine("This user already exists on the MQ server.");
                ////        break;
                ////    case false:
                ////        // Create the new user on the MQ Server
                ////        Console.WriteLine("This user will be created on the MQ server.");

                ////        string uri = $"http://YourServer:AndPort/api/users/{userName}";

                ////        MqUser mqUser = new MqUser
                ////        {
                ////            password = password,
                ////            tags = "administrator"
                ////        };

                ////        string info = JsonConvert.SerializeObject(mqUser);
                ////        StringContent content = new StringContent(info, Encoding.UTF8, "application/json");

                ////        httpResponseMessage = await httpClient.PutAsync(uri, content);
                ////        if (!httpResponseMessage.IsSuccessStatusCode)
                ////        {
                ////            Console.WriteLine("There was an error creating the MQ user account.");
                ////            Thread.Sleep(2500);
                ////            return false;
                ////        }

                ////        uri = $"http://YourServer:AndPort/api/permissions/%2F/{userName}";

                ////        MqPermissions mqPermissions = new MqPermissions
                ////        {
                ////            configure = ".*",
                ////            write = ".*",
                ////            read = ".*"
                ////        };

                ////        info = JsonConvert.SerializeObject(mqPermissions);
                ////        content = new StringContent(info, Encoding.UTF8, "application/json");

                ////        httpResponseMessage = await httpClient.PutAsync(uri, content);

                ////        if (!httpResponseMessage.IsSuccessStatusCode)
                ////        {
                ////            Console.WriteLine("There was an error creating the permissions on the MQ user account.");
                ////            Thread.Sleep(2500);
                ////            return false;
                ////        }

                ////        break;
                ////}
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            //_messageQueue = new SnapManagerMessageQueue();
            //Content = new SnapManager(_messageQueue) { Tag = "EEEEEEEEEEEE" };
        }

    }
}
