using Systems;
using Systems.Interfaces;
using Core.Character;
using UnityEngine;

namespace Core.Behaviour
{
    public class CharacterInputService : MonoBehaviour
    {
        [SerializeField] private CharacterEntity _characterEntity;
        
        private IUserInput _input;
        
        private void Awake()
        {
            _input = new UserInput(true);
            _input.MoveDirection += _characterEntity.HandleMovementVector;
            _input.Jump += _characterEntity.HandleJump;
        }

        private void Update() => _input.Tick();
    }
}