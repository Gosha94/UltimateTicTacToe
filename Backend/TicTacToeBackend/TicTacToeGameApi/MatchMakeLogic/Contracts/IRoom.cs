using System;
using System.Collections.Generic;

namespace TicTacToeGameApi.MatchMakeLogic.Contracts
{
    internal interface IRoom
    {
        string Add(string userName);
        string Remove(string userName);
        bool Clear();
        IEnumerable<string> GetAllPlayers();
    }
}