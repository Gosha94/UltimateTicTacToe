using System;
using System.Collections.Generic;

namespace TicTacToeGameApi.MatchMakeLogic.Models
{
    public class WaitingRoom
    {

        /// <summary>
        /// Св-во описывает Список игроков, попавших в Комнату Ожидания
        /// </summary>
        public List<Player> PlayersWaitGameList { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public WaitingRoom()
        {
            PlayersWaitGameList = new List<Player>();
        }        

        /// <summary>
        /// Метод добавляет Игрока в комнату Ожидания
        /// </summary>
        /// <param name="addingPlayer">Добавляемый игрок</param>
        public bool AddPlayerToWaitingRoom(Player addedPlayer)
        {
            PlayersWaitGameList.Add(new Player() { ConnectionGuid = new Guid(), UserName = "User_GeneratedInClass_WaitingRoom_For_Test" });
            return true;
        }

        /// <summary>
        /// Метод удаляет Игрока из комнаты Ожидания
        /// </summary>
        /// <param name="removedPlayer">Удаляемый игрок</param>
        public bool RemovePlayerFromWaitingRoom(Player removedPlayer)
            => PlayersWaitGameList.Remove(removedPlayer);

    }
}