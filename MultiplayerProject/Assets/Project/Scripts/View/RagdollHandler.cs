using System;
using UnityEngine;

namespace View
{
    [RequireComponent(typeof(Animator))]
    public class RagdollHandler : MonoBehaviour
    {
        private Rigidbody[] _bodies;
        private Collider[] _colliders;
        private Animator _animator;

        private void OnEnable()
        {
            _animator = GetComponent<Animator>();
            GetAllPhysicsElements();
            
            DisableRagdoll();
        }

        private void GetAllPhysicsElements()
        {
            _bodies = GetComponentsInChildren<Rigidbody>();
            _colliders = GetComponentsInChildren<Collider>();
        }

        public void EnalbeRagdoll()
        {
            _animator.enabled = false;

            if (_bodies == null) 
                return;
            
            foreach (var body in _bodies)
                body.isKinematic = false;
            
            if(_colliders == null)
                return;

            foreach (var coll in _colliders)
                coll.enabled = true;
        }

        public void DisableRagdoll()
        {
            _animator.enabled = true;
            
            if (_bodies == null) 
                return;
            
            foreach (var body in _bodies)
                body.isKinematic = true;
            
            if(_colliders == null)
                return;

            foreach (var coll in _colliders)
                coll.enabled = false;
        }
    }
}