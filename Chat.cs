using System;
using System.Collections.Generic;

namespace Chapter_1.Task_3
{
    internal class Chat
    {
        private Room _room;
        private List<string> messages = new List<string>();

        public Chat(Room room)
        {
            _room = room;
        }

        public event EventHandler MessageSend;

        public string LastString => messages[^0];

        public void Send(Player sender, string message)
        {
            if (_room.IsGameMode && sender.Ready == false)
            {
                throw new InvalidOperationException();
            }

            messages.Add(message);
            MessageSend(this, new EventArgs());
        }

        public void Subscribe(Player player)
        {
            MessageSend += player.MessageSend;
        }

        public void Unsubscribe(Player player)
        {
            MessageSend -= player.MessageSend;
        }
    }
}
