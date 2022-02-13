using UltimateTicTacToeServer.Data;

namespace UltimateTicTacToeServer.Services
{
    public class RoomManagementService
    {

        private readonly GameRoom _waitingRoom;
        public List<GameRoom> GameRooms { get; }

        private readonly int _maxLimitOfRoomsOnServer;

        public RoomManagementService()
        {
            _maxLimitOfRoomsOnServer = 10;
            _waitingRoom = new GameRoom(20);
            GameRooms = new List<GameRoom>();            
        }


        public void AutoMinimizeRoomsNumber()
        {
            SortPlayersBetweenHalfEmptyRoomsScheduleWork();
            DropEmptyRoomsScheduleWork();
        }

        /// <summary>
        /// Метод сортирует игроков между комнатами, оптимизирует кол-во комнат
        /// </summary>
        private void SortPlayersBetweenHalfEmptyRoomsScheduleWork()
        {

        }

        /// <summary>
        /// Метод чистит пустые комнаты в общем списке
        /// </summary>
        /// <returns>Число удаленных комнат</returns>
        private int DropEmptyRoomsScheduleWork()
            => GameRooms.RemoveAll(x => x.Empty);


        #region Old Shit        

        public void StartGamesInReadyRooms()
        {
            //_gameRooms.ForEach(room =>
            //{
            //    if (room.IsRoomReady)
            //    {
            //        room.Game.Start();
            //    }
            //});
        }

        public void ControlMaxRoomNumber()
        {
            if (GameRooms.Count > _maxLimitOfRoomsOnServer)
            {
                throw new IndexOutOfRangeException($"Игровой сервер загибается! Превышен лимит открытых комнат на сервере! Лимит: {_maxLimitOfRoomsOnServer} Достигнуто: {GameRooms.Count}");
            }
        }

        #endregion

    }
}
