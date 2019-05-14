using UnityEngine;

#pragma warning disable 618

namespace Networking
{
    public class GameController : MonoBehaviour
    {
        public ManagerOfNetworks NetworkManager;

        public void Start()
        {
            PlayerContainer.OnLocalPlayerAdded += OnLocalPlayerAdded;
        }

        private void OnLocalPlayerAdded(Player localplayer)
        {
            var pos = Random.value * 3;
            localplayer.SpawnSomething(new Vector3(pos, 0, 0));
        }

        private void OnGUI()
        {
            if (GUI.Button(new Rect(10, 10, 100, 50), "Server"))
            {
                NetworkManager.ServerStart();
            }

            if (GUI.Button(new Rect(10, 70, 100, 50), "Client"))
            {
                NetworkManager.ClientStart();
            }
        }
    }
}