namespace UltimateTicTacToeServer.Data
{
    public class GameRoom
    {
        /// <summary>
        /// Поле описывает Список игроков, попавших в Комнату Ожидания
        /// </summary>
        private readonly List<Player> _playersList;

        /// <summary>
        /// Поле описывает Чат для игроков в комнате
        /// </summary>
        //private readonly GameChat _gameChat;

        //internal Game Game { get; private set; }

        /// <summary>
        /// Св-во описывает лимит игроков в комнате
        /// </summary>
        public int PlayersRoomLimit { get; }

        public bool IsRoomReady
        {
            get => _playersList.All(x => x.IsReadyForGame);
        }

        public bool Empty { get => _playersList.Count == 0; }

        /// <summary>
        /// Св-во описывает идентификатор комнаты
        /// </summary>
        public Guid RoomGuid { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public GameRoom(int playersRoomLimit)
        {
            _playersList = new List<Player>();
            //_gameChat = new GameChat();
            PlayersRoomLimit = playersRoomLimit;
            RoomGuid = new Guid();
        }

        /// <summary>
        /// Метод добавляет Игрока в комнату
        /// </summary>
        /// <param name="userName">Добавляемый игрок</param>
        public string Add(string userName)
        {
            if (_playersList.Count >= PlayersRoomLimit)
            {
                throw new ArgumentOutOfRangeException($"Игрок не добавлен! Лимит игроков в комнате {RoomGuid} превысил {PlayersRoomLimit} ед.");
            }

            var addedPlayer = new Player(userName);
            _playersList.Add(addedPlayer);

            return addedPlayer.PlayerName;
        }

        /// <summary>
        /// Метод удаляет Игрока из комнаты
        /// </summary>
        /// <param name="userName">Удаляемый игрок</param>
        public bool Remove(string userName)
        {
            var findedPlayer = _playersList.Find(x => x.PlayerName == userName);
            
            if (findedPlayer is null)
            {
                return false;
            }

            return _playersList.Remove(findedPlayer);
        }

        /// <summary>
        /// Метод очищает комнату
        /// </summary>
        /// <returns>Статус очистки комнаты</returns>
        public bool Clear()
        {
            _playersList.Clear();

            if (_playersList.Count > 0)
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

            foreach (var player in _playersList)
            {
                resultPlayersDataList.Add($"{player.PlayerName}");
            }

            return resultPlayersDataList;
        }
    }
}
