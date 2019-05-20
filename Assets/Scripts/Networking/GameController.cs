using UnityEngine;

#pragma warning disable 618

namespace Networking
{
    public class GameController : MonoBehaviour
    {
        public ManagerOfNetworks NetworkManager;

        private void Update()
        {
            if (PlayerContainer.LocalPlayer && Input.GetMouseButtonDown(0))
            {
                PlayerContainer.LocalPlayer.SpawnSomething();
            }
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