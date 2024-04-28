using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Systems
{
    public class RoomHandler : MonoBehaviourPunCallbacks
    {
        [SerializeField] private CharacterSpawnHandler _characterSpawnHandler;
        
        private void Awake()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log($"<color=green> Connected to Master </color>");
            PhotonNetwork.JoinLobby();
        }

        public override void OnJoinedLobby()
        {
            Debug.Log($"<color=cyan> Connected to lobby </color>");
            RoomOptions roomOptions = new RoomOptions
            {
                MaxPlayers = 4
            };
            PhotonNetwork.JoinOrCreateRoom("Test", roomOptions, null);
        }

        public override void OnJoinedRoom()
        {
            Debug.Log($"<color=pink> Connected to Room </color>");
            _characterSpawnHandler.CreateCharacter();
        }
        
      
    }
}