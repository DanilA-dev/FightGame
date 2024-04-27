using Core.Character;
using Core.Interfaces;
using Project.Scripts.Data.CharacterStatesContext;
using UnityEngine;
using View;

namespace CharacterFSM
{
    public class CharacterJumpState : BaseCharacterState
    {
        private readonly Rigidbody _rigidbody;
        private readonly CharacterMovementData _data;
        private IMover _mover;
        
        private CountdownTimer _jumpTimer;
        private float _jumpVelocity;
        
        public CountdownTimer JumpTimer => _jumpTimer;

        public override float ExitTime => _jumpTimer.RemainingTime;
        public CharacterJumpState(CharacterEntity character, CharacterView view,
            CharacterMovementData data, IMover mover) 
            : base(character, view)
        {
            _data = data;
            _mover = mover;
            _rigidbody = character.GetComponent<Rigidbody>();
            
            _jumpTimer = new CountdownTimer(_data.JumpDuration);
            _jumpTimer.OnTimerStart += () => _jumpVelocity = _data.JumpForce;
        }

        public override void OnEnter()
        {
            Debug.Log("Enter jump state");
            _view.Jump();
        }

        public override void OnUpdate()
        {
            _jumpTimer.Tick(Time.deltaTime);
            UpdateRotation();
        }

        private void UpdateRotation()
        {
            var speed = _data.RotateSpeed;
            _character.HandleInputRotation(speed);
        }

        public override void OnFixedUpdate()
        {
            HandleJump();
            HandleMove();
        }

        private void HandleMove()
        {
            var speed = _data.MoveSpeed * Time.fixedDeltaTime;
            _mover.Move(speed);
        }

        private void HandleJump()
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpVelocity, _rigidbody.velocity.z);
        }

    }
}