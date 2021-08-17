using System;

namespace Chapter_1.Task_3
{
    internal class Player
    {
        private Room _room;
        private Chat _chat;

        public bool Connected { get; private set; }

        public bool Ready
        {
            get
            {
                return Ready;
            }

            private set
            {
                if (_room.FilledIn)
                {
                    throw new InvalidOperationException();
                }

                Ready = value;
            }
        }

        public void OnConnect(Room room)
        {
            Connected = true;
            _room = room;
            _chat = _room.Chat;

            _chat.Send(this, "Hey, everybody!");

            Ready = true;
        }

        public void OnDisconnect(Room room)
        {
            Connected = false;
            _room = null;
            _chat = _room.Chat;

            _chat.Send(this, "Hey, everybody!");

            Ready = false;
        }

        public void MessageSend(object sender, EventArgs e)
        {
            string message = ((Chat)sender).LastString;
            Console.WriteLine(message);
        }
    }
}
