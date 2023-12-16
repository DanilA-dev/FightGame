using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    public class UIPlayerJoinContent : MonoBehaviour
    {
        [SerializeField] private PlayerInputManager _playerInputManager;
        [SerializeField] private List<UIPlayerJoinPanel> _joinPanel;

        private void Start()
        {
            _playerInputManager.onPlayerJoined += OnPlayerJoin;
        }

        private void OnPlayerJoin(UnityEngine.InputSystem.PlayerInput input)
        {
            _joinPanel.ForEach(p => p.JoinPlayer((int)input.user.id));
        }
    }
}