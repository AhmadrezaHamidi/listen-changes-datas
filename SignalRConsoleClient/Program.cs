using System.Threading;
using System.IO;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Http.Connections;

namespace consoelApps
{
    class Program
    {
        static HubConnection connection;
        // static HttpTransportType transportType;
        // private string hubUrl;

        static void Main(string[] args)
        {
            while (true)
            {

                var token = args[0];

 

            //     hubConnection = new HubConnectionBuilder()
            // .WithUrl(hubUrl, transportType)
            // .Build();

                // var connection = new HubConnectionBuilder()
                // .WithUrl("http://localhost:8634/SignalRHub")
                // //.WithConsoleLogger()
                // .WithTransport(Microsoft.AspNetCore.Sockets.TransportType.WebSockets)
                // .Build();


                connection = new HubConnectionBuilder()
                .WithUrl(
                    $"http://82.99.217.85:5028/booxell"
                    +
                    $"?access_token={token}"
                    , (config) =>
                    {
                        config.UseDefaultCredentials = true;
                        config.AccessTokenProvider = () => Task.FromResult(token);
                      ///  config.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransports.All;
                    })



            //  connection = new HubConnectionBuilder()
            // .WithUrl(hubUrl, transportType)
            // .Build();


                    //.WithTransport(Microsoft.AspNetCore.Sockets.TransportType.WebSockets)

                    // .WithTransport(Microsoft.AspNetCore.Sockets.TransportType.WebSockets)

                    .WithAutomaticReconnect().Build();

                connection.Closed += async (error) =>
                {
                    await Task.Delay(new Random().Next(0, 5) * 1000);
                    await connection.StartAsync();
                };

                try
                {
                    connection.StartAsync()
                    .GetAwaiter()
                    .GetResult();

                    Console.WriteLine("Connection started state is : {0}", connection.State);

                    connection
                    .InvokeAsync("OnConnected")

                    .GetAwaiter()
                    .GetResult();
                    Console.WriteLine("success");
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                Program.SendToUser();
                Program.SendFeedsToUser();

                Thread.Sleep(300000);
                connection.InvokeAsync("OnDisConnected", "vestaabner");
            }

        }


        private static async void SendFeedsToUser()
        {
            connection.On<string, object>("SendFeedsToUser", (userId, data) =>
           {
               var newMessage = $"{userId}: {data}";
               Console.WriteLine(newMessage);
           });
        }
        private static async void SendToUser()
        {

            connection.On<string, object>("SendToUser", (userId, data) =>
                      {
                          var newMessage = $"{userId}: {data}";
                          Console.WriteLine(newMessage);
                      });
        }



    }
}
