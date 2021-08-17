using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chapter_1.Task_3
{
    internal class Room
    {
        private int _readyPlayers;
        private readonly int _maxConnections;
        private bool _isGameMode = false;
        private List<Player> _players = new List<Player>();

        public Room(int maxConnections = 5)
        {
            _maxConnections = maxConnections;
            Chat = new Chat(this);
            CheckingReadinessAsync();
        }

        public Chat Chat { get; private set; }

        public int Connections => _players.Count;

        public bool FilledIn => _readyPlayers == _maxConnections;

        public bool IsGameMode => _isGameMode;

        public void Connect(Player player)
        {
            if (FilledIn)
            {
                throw new InvalidOperationException();
            }

            _players.Add(player);
            Chat.Subscribe(player);
            player.OnConnect(this);
        }

        public void Disconnect(Player player)
        {
            _players.Remove(player);
            Chat.Unsubscribe(player);
            player.OnDisconnect(this);
        }

        private async void CheckingReadinessAsync()
        {
            while (true)
            {
                _readyPlayers = 0;

                foreach (var player in _players)
                {
                    if (player.Ready)
                    {
                        _readyPlayers += 1;
                    }
                }

                // Start game
                if (FilledIn)
                {
                    _isGameMode = true;

                    foreach (var player in _players)
                    {
                        if (player.Ready == false)
                        {
                            Chat.Unsubscribe(player);
                        }
                    }

                    return;
                }

                await Task.Delay(1000);
            }
        }
    }
}
