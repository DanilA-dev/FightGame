using System;
using Systems.Interfaces;
using UnityEngine;

namespace Systems
{
    public class UserInput : IUserInput
    {
        private Input _input;

        private Vector2 _moveDir;

        public event Action<Vector2> MoveDirection;
        public event Action Jump;

        public UserInput(bool enableOnInit)
        {
            _input = new Input();
            ToggleInput(enableOnInit);
            InitActions();
        }

        private void InitActions()
        {
            _input.Movement.Jump.performed += _ => Jump?.Invoke();
        }
        
        public void Tick()
        {
            UpdateMoveDirection();
        }

        private void UpdateMoveDirection()
        {
            _moveDir = _input.Movement.Move.ReadValue<Vector2>();
            MoveDirection?.Invoke(_moveDir);
        }


        public void ToggleInput(bool value)
        {
            if(value)
                _input?.Enable();
            else
                _input?.Disable();            
        }

    }
}