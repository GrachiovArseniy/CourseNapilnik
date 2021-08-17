using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter_1.Task_3
{
    internal class RoomManager
    {
        private static List<Room> _rooms = new List<Room>(5);

        public static Room CreateRoom()
        {
            Room newRoom = new Room();
            _rooms.Add(newRoom);
            Sort();
            return newRoom;
        }

        public static void Connect(Player player)
        {
            foreach (var room in _rooms)
            {
                if (room.FilledIn)
                {
                    break;
                }

                room.Connect(player);
                return;
            }

            throw new Exception("Not enough space");
        }

        // Sorting rooms in descending order of the number of connections, for optimal matchmaking of player
        private static void Sort()
        {
            _rooms = _rooms.OrderBy(i => i.Connections).ToList();
        }
    }
}
