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
                var x = Random.value * 6 - 3;
                var y = Random.value * 6 - 3;
                PlayerContainer.LocalPlayer.SpawnSomething(new Vector3(x, y, 0));
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