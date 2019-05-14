using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable 618

namespace Networking
{
    public class Player : NetworkBehaviour
    {
        public GameObject SpawnablePrefab;

        private void Start()
        {
            if (isLocalPlayer)
            {
                PlayerContainer.LocalPlayer = this;
            }
        }

        public void SpawnSomething(Vector3 position)
        {
            CmdSpawnSomething(position);
        }

        [Command]
        private void CmdSpawnSomething(Vector3 position)
        {
            var player = Object.Instantiate(SpawnablePrefab, position, Quaternion.identity, transform);
            NetworkServer.SpawnWithClientAuthority(player, PlayerContainer.LocalPlayer.gameObject);
        }
    }
}