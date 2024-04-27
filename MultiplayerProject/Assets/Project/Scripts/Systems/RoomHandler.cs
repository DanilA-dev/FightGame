using System;
using UnityEngine;
using Photon.Pun;

namespace Systems
{
    public class RoomHandler : MonoBehaviourPunCallbacks
    {
        private void Awake()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log($"<color=green> Connected to Master </color>");
        }

        public override void OnJoinedLobby()
        {
            Debug.Log($"<color=green> Connected to lobby </color>");
        }

        public override void OnJoinedRoom()
        {
            Debug.Log($"<color=green> Connected to Room </color>");
        }
        
      
    }
}