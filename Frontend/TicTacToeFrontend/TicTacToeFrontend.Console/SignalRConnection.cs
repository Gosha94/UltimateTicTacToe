using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace TicTacToeFrontend.ConsoleApp
{
    internal sealed class SignalRConnection
    {
        public async void StartConnectionAsync()
        {

            var url = "https://localhost:49157/lobbyshub";

            var hubConnection = new HubConnectionBuilder()
                .WithUrl(url)
                .WithAutomaticReconnect()
                .Build();

            Action<string> receiverAction = ReceiveMessage;

            hubConnection.On("ReceiveMessageOnClient", receiverAction);

            hubConnection
                .StartAsync()
                .Wait();

            await hubConnection.InvokeAsync("ServerSend", "Hello pidor!");

            Console.WriteLine("For exit press any key...");
            Console.ReadKey();
        }

        private static void ReceiveMessage(string msg)
        {
            Console.WriteLine($"Received message: {msg}");
        }

    }
}