using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable 618

namespace Networking
{
    public class Player : NetworkBehaviour
    {
        public GameObject SpawnablePrefab;
        public Camera Camera;

        public GameObject ObjectToMove;

        private void Start()
        {
            if (isLocalPlayer)
            {
                PlayerContainer.LocalPlayer = this;
            }

            Camera = FindObjectOfType<Camera>();
        }

        public void SpawnSomething()
        {
            var ray = Camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (ObjectToMove == hit.collider.gameObject)
                {
                    CmdMoveObject(ObjectToMove.GetComponent<NetworkIdentity>().netId, ObjectToMove.transform.position);
                    ObjectToMove = null;
                }
                else
                {
                    ObjectToMove = hit.collider.gameObject;
                }
            }
            else
            {
                var pos = new Vector3(ray.origin.x, ray.origin.y, 0);
                CmdSpawnSomething(pos);
            }
        }

        private void Update()
        {
            if (ObjectToMove)
            {
                var camRay = Camera.ScreenPointToRay(Input.mousePosition);
                var newPosition = new Vector3(camRay.origin.x, camRay.origin.y, 0);
                ObjectToMove.transform.position = newPosition;
            }
        }

        [Command]
        private void CmdSpawnSomething(Vector3 position)
        {
            var player = Object.Instantiate(SpawnablePrefab, position, Quaternion.identity, transform);
            NetworkServer.Spawn(player);
        }

        [Command]
        private void CmdMoveObject(NetworkInstanceId id, Vector3 newPosition)
        {
            var go = NetworkServer.FindLocalObject(id);
            go.transform.position = newPosition;
            RpcMoveObject(id, newPosition);
        }

        [ClientRpc]
        private void RpcMoveObject(NetworkInstanceId id, Vector3 newPosition)
        {
            var go = ClientScene.FindLocalObject(id);
            go.transform.position = newPosition;
        }
    }
}