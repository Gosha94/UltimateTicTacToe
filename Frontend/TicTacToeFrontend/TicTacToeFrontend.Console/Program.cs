using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace TicTacToeFrontend.ConsoleApp
{
    class Program
    {

        private static HubConnection _lobbyConnection;

        static void Main(string[] args)
        {           

            Console.WriteLine("Hello from TicTacToe Console Client SignalR");

            SetUpGameServer();

            _lobbyConnection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                Console.WriteLine($"TicTacToe Client trying to Reconnect!");
                await _lobbyConnection.StartAsync();
            };

            _lobbyConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Dispatcher.Invoke(() =>
                {
                    var newMessage = $"{user}: {message}";
                    messagesList.Items.Add(newMessage);
                });
            });

            try
            {
                await _lobbyConnection.StartAsync();
                messagesList.Items.Add("Connection started");
                connectButton.IsEnabled = false;
                sendButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }

            Console.WriteLine($"TicTacToe Game Backend running successfully!");


            Console.ReadLine();

        }

        private static void SetUpGameServer()
        {
            var signalrServerUrl = "https://localhost:49159/lobbysHub";

            _lobbyConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(signalrServerUrl))
                    .WithAutomaticReconnect()
                        .Build();
        }

    }
}