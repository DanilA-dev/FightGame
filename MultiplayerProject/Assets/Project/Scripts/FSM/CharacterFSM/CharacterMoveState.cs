using Core.Character;
using Core.Interfaces;
using Project.Scripts.Data.CharacterStatesContext;
using UnityEngine;
using View;

namespace CharacterFSM
{
    public class CharacterMoveState : BaseCharacterState
    {
        private CharacterMovementData _data;

        private IMover _mover;
        private float _animVelocity;
        private float _animSpeed;
        private float _animVelocitySpeed = 0.25f;

        public override float ExitTime => 0;
        
        public CharacterMoveState(CharacterEntity character, CharacterView view,
            CharacterMovementData data, IMover mover)
            : base(character, view)
        {
            _data = data;
            _mover = mover;
        }
        
        public override void OnEnter()
        {
            Debug.Log("Enter Move State");
        }

        public override void OnUpdate()
        {
            RotateCharacter();
            UpdateBlendTree();
        }

        public override void OnFixedUpdate()
        {
            var speed = _data.MoveSpeed * Time.fixedDeltaTime;
            MoveCharacter(speed);
        }

        private void MoveCharacter(float speed) => _mover.Move(speed);

        private void RotateCharacter()
        {
            var speed = _data.RotateSpeed;
            _character.HandleInputRotation(speed);
        }
        
        private void UpdateBlendTree()
        {
            _animSpeed = Mathf.SmoothDamp(_animSpeed, 1, ref _animVelocity, _animVelocitySpeed);
            _view.UpdateMovementParameter(_animSpeed);
        }
    }
}