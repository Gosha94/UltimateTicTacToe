using System.Collections.Generic;
using TicTacToeGameApi.MatchMakeLogic.Contracts;

namespace TicTacToeGameApi.MatchMakeLogic.Models
{
    public sealed class GameRoom : IRoom
    {

        /// <summary>
        /// Св-во описывает Список игроков, попавших в Комнату Ожидания
        /// </summary>
        private readonly List<Player> _playersWaitGameList;

        private readonly GameChat _gameChat;

        /// <summary>
        /// Конструктор
        /// </summary>
        public GameRoom()
        {
            _playersWaitGameList = new List<Player>();
            _gameChat = new GameChat();
        }

        /// <summary>
        /// Метод добавляет Игрока в комнату Ожидания
        /// </summary>
        /// <param name="userName">Добавляемый игрок</param>
        public string Add(string userName)
        {
            var addedPlayer = new Player(userName);
            _playersWaitGameList.Add(addedPlayer);
            
            return addedPlayer.PlayerName;
        }

        /// <summary>
        /// Метод удаляет Игрока из комнаты Ожидания
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
        /// Метод возвращает список игроков в комнате ожидания
        /// </summary>
        /// <returns></returns>
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