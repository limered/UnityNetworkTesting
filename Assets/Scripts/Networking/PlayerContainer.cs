using UnityEngine;

namespace Networking
{
    public delegate void LocalPlayerDelegate(Player localPlayer);

    public static class PlayerContainer
    {
        public static LocalPlayerDelegate OnLocalPlayerAdded;
        private static Player _localPlayer;

        public static Player LocalPlayer
        {
            get { return _localPlayer; }
            set
            {
                _localPlayer = value;
                OnLocalPlayerAdded?.Invoke(_localPlayer);
            }
        }
    }
}