using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace consoelApps
{
    public class MessageClient
    {
        private HubConnection _connection;
        private HubConnectionBuilder _connectionBuilder;
        private bool isCompleted = false;

        public void CreateConncetion()
        {
            _connectionBuilder = new HubConnectionBuilder();
            _connection = _connectionBuilder.WithUrl("http://localhost:6028/BooxellHub")
            .WithAutomaticReconnect().Build();

            if(_connection.State == HubConnectionState.Disconnected)
            {
                _connection.On<string>("OnConnected", (string messageContent) => 
                {
                    Console.WriteLine(messageContent);
                    isCompleted = true;
                });

                _connection.StartAsync().GetAwaiter().GetResult();

                while(!isCompleted)
                {
                    Task.Delay(10).GetAwaiter().GetResult();
                }
            }
             //connection.StateChanged += connection_StateChanged;
        }
        public void DisCreateConncetion()
        {
            _connectionBuilder = new HubConnectionBuilder();
            _connection = _connectionBuilder.WithUrl("http://localhost:6028/BooxellHub")
            .WithAutomaticReconnect().Build();

            if(_connection.State == HubConnectionState.Connecting)
            {
                _connection.On<string>("OnConnected", (string messageContent) => 
                {
                    Console.WriteLine(messageContent);
                    isCompleted = true;
                });

                _connection.StartAsync().GetAwaiter().GetResult();

                while(!isCompleted)
                {
                    Task.Delay(10).GetAwaiter().GetResult();
                }
            }
        }
    }
}