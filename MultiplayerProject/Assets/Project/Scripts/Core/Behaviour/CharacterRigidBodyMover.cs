using Systems.Interfaces;
using Core.Interfaces;
using Project.Scripts.Data.CharacterStatesContext;
using UnityEngine;

namespace Core.Behaviour
{
    public class CharacterRigidBodyMover : IMover
    {
        private Vector3 _moveDir;
        private Rigidbody _rigidbody;
        private CharacterMovementData _moveData;

        public Vector3 Direction
        {
            get => _moveDir;
            set => _moveDir = value;
        }

        public CharacterRigidBodyMover(Rigidbody rigidbody)
        {
            _rigidbody = rigidbody;
        }

        
        public void Move(float speed)
        {
            _rigidbody.velocity = new Vector3(_moveDir.x * speed, _rigidbody.velocity.y, _moveDir.z * speed);
        }

    }
}