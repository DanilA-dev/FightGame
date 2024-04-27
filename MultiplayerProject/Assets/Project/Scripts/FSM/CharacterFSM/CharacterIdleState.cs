using Core.Character;
using UnityEngine;
using View;

namespace CharacterFSM
{
    public class CharacterIdleState : BaseCharacterState
    {
        private Rigidbody _rigidbody;
        
        private float _animSpeed;
        private float _animVelocity;
        private float _animVelocitySpeed = 0.8f;

        public override float ExitTime => 0;
        
        public CharacterIdleState(CharacterEntity character, CharacterView view) : base(character, view)
        {
            _rigidbody = character.GetComponent<Rigidbody>();
        }

        public override void OnEnter()
        {
            Debug.Log("Enter Idle State");
            _rigidbody.velocity = new Vector3(0, _rigidbody.velocity.y, 0);
            
        }

        public override void OnUpdate()
        {
           UpdateBlendTree();
        }


        private void UpdateBlendTree()
        {
            _animSpeed = Mathf.SmoothDamp(_animSpeed, 0, ref _animVelocity, _animVelocitySpeed);
            _view.UpdateMovementParameter(_animSpeed);
        }
    }
}