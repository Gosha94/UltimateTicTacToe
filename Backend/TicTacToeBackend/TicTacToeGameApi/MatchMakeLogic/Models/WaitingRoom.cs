using System;
using System.Collections.Generic;

namespace TicTacToeGameApi.MatchMakeLogic.Models
{
    public class WaitingRoom
    {

        /// <summary>
        /// Св-во описывает Список игроков, попавших в Комнату Ожидания
        /// </summary>
        private readonly List<Player> _playersWaitGameList;

        /// <summary>
        /// Конструктор
        /// </summary>
        public WaitingRoom()
        {
            _playersWaitGameList = new List<Player>();
        }        

        /// <summary>
        /// Метод возвращает список игроков в комнате ожидания
        /// </summary>
        /// <returns></returns>
        public List<string> GetPlayersListFromWaitingRoom()
        {
            var resultPlayersDataList = new List<string>();
            
            foreach (var player in _playersWaitGameList)
            {
                resultPlayersDataList.Add($"Nick - {player.UserName} | ConnectionGuid - {player.ConnectionGuid}");
            }

            return resultPlayersDataList;
        }

        /// <summary>
        /// Метод добавляет Игрока в комнату Ожидания
        /// </summary>
        /// <param name="addingPlayer">Добавляемый игрок</param>
        public bool AddPlayerToWaitingRoomOnUserName(string addedUserName)
        {
            _playersWaitGameList.Add(new Player() { ConnectionGuid = new Guid(), UserName = addedUserName });
            return true;
        }

        /// <summary>
        /// Метод удаляет Игрока из комнаты Ожидания
        /// </summary>
        /// <param name="removedPlayer">Удаляемый игрок</param>
        public bool RemovePlayerFromWaitingRoomOnUserName(string removedUserName)
        {
            var findedPlayer = _playersWaitGameList.Find(x => x.UserName == removedUserName);
            return _playersWaitGameList.Remove(findedPlayer);
        }
    }
}