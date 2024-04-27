using Core.Character;
using Core.Interfaces;
using Project.Scripts.Data.CharacterStatesContext;
using UnityEngine;
using View;

namespace CharacterFSM
{
    public class CharacterInAirState : BaseCharacterState
    {
        private CharacterMovementData _data;
        private IMover _mover;
        private Rigidbody _rigidbody;
        public override float ExitTime => 0;
        
        public CharacterInAirState(CharacterEntity character, CharacterView view,
            CharacterMovementData data, IMover mover) : base(character, view)
        {
            _data = data;
            _mover = mover;
            _rigidbody = character.GetComponent<Rigidbody>();
        }

        public override void OnEnter()
        {
            Debug.Log("Enter Air State");
            _view.InAir();
        }

        public override void OnUpdate()
        {
            HandleRotation();
        }

        public override void OnFixedUpdate()
        {
            HandleGravity();
            HandleMove();
        }

        private void HandleMove()
        {
            var modifier = 0.8f;
            var speed = (_data.MoveSpeed * modifier) * Time.fixedDeltaTime;
            _mover.Move(speed);
        }

        private void HandleGravity()
        {
            _rigidbody.velocity += Physics.gravity * (_data.GravityModifer * Time.fixedDeltaTime);
        }
        
        private void HandleRotation()
        {
            var speed = _data.RotateSpeed;
            _character.HandleInputRotation(speed);
        }
    }
}