using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR.Client;

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

            Console.WriteLine("Connection to Game Server success established!");
            Console.WriteLine("Please, enter UserName:");
            
            var inputUserName = Console.ReadLine().Trim();

            // Start connection
            hubConnection.StartAsync().ContinueWith(task => {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error opening the connection:{0}", task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine("Connected");
                }
            })
            // Проблема заключается в установлении соединения перед попыткой отправить сообщение в концентратор.
            // Это очень важно, поэтому важно дождаться завершения асинхронной задачи, что означает, что мы делаем ее синхронной, ожидая завершения задачи.
            .Wait();

            await hubConnection.InvokeAsync<bool>("AddNewPlayerToWaitingRoom", inputUserName).ContinueWith(task => {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error calling send: {0}",
                                      task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine($"Result of Adding User, receive on Client: {task.Result}");
                }
            });

            hubConnection.On<bool>("AddNewPlayerToWaitingRoom", flagOfAdd => { Console.WriteLine("PlayerAddedToWaitingRoom Invoked on Server!"); } );

            hubConnection.InvokeAsync<List<string>>("GetWaitingRoomPlayersList").Wait();

            hubConnection.On("GetWaitingRoomPlayersList", () => Console.WriteLine("AllUsersGetFromWaitingRoom Invoked!"));

            var usersTest = new List<string>() { "test1", "test2", "test3" };
            PrintListToConsoleAsync(usersTest);
            
            await hubConnection.InvokeAsync<bool>("RemovePlayerFromWaitingRoom", inputUserName).ContinueWith(task => {
                if (task.IsFaulted)
                {
                    Console.WriteLine("There was an error calling send: {0}",
                                      task.Exception.GetBaseException());
                }
                else
                {
                    Console.WriteLine($"Result of Remove User, receive on Client: {task.Result}");
                }
            });

            hubConnection.On<bool>("RemovePlayerFromWaitingRoom", flagOfRemoving => { Console.WriteLine($"PlayerRemovedFromWaitingRoom Invoked! Server Method Returned Flag State: {flagOfRemoving}"); } );

            //allUserList = await hubConnection.InvokeAsync<List<string>>("GetWaitingRoomPlayersList");
            
            //PrintListToConsoleAsync(usersTest);
        }

        private static void PrintListToConsoleAsync<T>(List<T> listForPrint)
        {
            Task.Run(() => 
            {
                Console.WriteLine("Users on Server WaitingRoom:");

                foreach (var elem in listForPrint)
                {
                    Console.WriteLine(elem);
                }
            });
        }

        //private static void PlayerAddedToWaitingRoom()
        //{
        //    Console.WriteLine("PlayerAddedToWaitingRoom Invoked!");
        //}

        //private static void PlayerRemovedFromWaitingRoom()
        //{
        //    Console.WriteLine("PlayerRemovedFromWaitingRoom Invoked!");
        //}

        //private static void AllUsersGetFromWaitingRoom()
        //{
        //    Console.WriteLine("AllUsersGetFromWaitingRoom Invoked!");
        //}

    }
}