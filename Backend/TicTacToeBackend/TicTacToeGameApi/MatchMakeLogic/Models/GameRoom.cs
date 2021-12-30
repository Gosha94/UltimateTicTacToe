using System;
using System.Linq;
using System.Collections.Generic;
using TicTacToeGameApi.MatchMakeLogic.Contracts;

namespace TicTacToeGameApi.MatchMakeLogic.Models
{
    internal sealed class GameRoom : IRoom
    {

        /// <summary>
        /// Поле описывает Список игроков, попавших в Комнату Ожидания
        /// </summary>
        private readonly List<Player> _playersWaitGameList;

        /// <summary>
        /// Поле описывает Чат для игроков в комнате
        /// </summary>
        private readonly GameChat _gameChat;

        internal Game Game { get; private set; }

        /// <summary>
        /// Св-во описывает лимит игроков в комнате
        /// </summary>
        internal int PlayersRoomLimit { get; }

        internal bool IsRoomReady
        {
            get => _playersWaitGameList.All(x => x.IsReadyForGame);
        }
        /// <summary>
        /// Св-во описывает идентификатор комнаты
        /// </summary>
        internal Guid RoomGuid { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public GameRoom(int playersRoomLimit)
        {
            _playersWaitGameList = new List<Player>();
            _gameChat = new GameChat();
            PlayersRoomLimit = playersRoomLimit;
            RoomGuid = new Guid();
        }

        /// <summary>
        /// Метод добавляет Игрока в комнату
        /// </summary>
        /// <param name="userName">Добавляемый игрок</param>
        public string Add(string userName)
        {
            if (_playersWaitGameList.Count >= PlayersRoomLimit)
            {
                throw new ArgumentOutOfRangeException($"Лимит игроков в комнате {RoomGuid} превысил {PlayersRoomLimit} ед.");
            }

            var addedPlayer = new Player(userName);
            _playersWaitGameList.Add(addedPlayer);
            
            return addedPlayer.PlayerName;
        }

        /// <summary>
        /// Метод удаляет Игрока из комнаты
        /// </summary>
        /// <param name="userName">Удаляемый игрок</param>
        public string Remove(string userName)
        {
            var findedPlayer = _playersWaitGameList.Find(x => x.PlayerName == userName);
            _playersWaitGameList.Remove(findedPlayer);
            return findedPlayer.PlayerName;
        }

        /// <summary>
        /// Метод очищает комнату
        /// </summary>
        /// <returns>Статус очистки комнаты</returns>
        public bool Clear()
        {
            _playersWaitGameList.Clear();
            
            if (_playersWaitGameList.Count > 0)
            {
                return false;
            }

            return true;
        }
        
        /// <summary>
        /// Метод возвращает список игроков в комнате
        /// </summary>
        /// <returns>List of Player Logins</returns>
        public IEnumerable<string> GetAllPlayers()
        {
            var resultPlayersDataList = new List<string>();

            foreach (var player in _playersWaitGameList)
            {
                resultPlayersDataList.Add($"{player.PlayerName}");
            }

            return resultPlayersDataList;
        }
        
    }
}