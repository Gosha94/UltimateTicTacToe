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

            Console.Read();
        }
    }
}