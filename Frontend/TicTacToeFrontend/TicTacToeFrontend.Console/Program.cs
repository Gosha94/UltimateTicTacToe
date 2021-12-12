using System;
using TicTacToeFrontend.ConsoleApp.Views;

namespace TicTacToeFrontend.ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            var connection = new SignalRConnection();
            connection.StartConnectionAsync();
            WaitingRoomContentView w = new WaitingRoomContentView();

            w.ClearConsole();
            Console.Read();
        }
    }
}