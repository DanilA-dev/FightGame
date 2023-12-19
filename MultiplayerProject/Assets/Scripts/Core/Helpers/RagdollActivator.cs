using System;
using UnityEngine;
using System.Linq;

namespace Misc
{
    public class RagdollActivator : MonoBehaviour
    {
        [SerializeField] private Transform _baseRoot;
        [SerializeField] private Transform _boneRoot;


        private Animator _animator;
        private Collider[] _ragdollColliders;
        private Rigidbody[] _ragdollBodies;
        private Collider[] _baseColliders;

        public event Action OnRagdollEnable;
        public event Action OnRagdollDisable;

        private void Awake()
        {
            FindAllColliders();
        }

        private void Start()
        {
            DisableRagdoll();
        }

        private void FindAllColliders()
        {
            _ragdollColliders = _boneRoot.GetComponentsInChildren<Collider>();
            _ragdollBodies = _boneRoot.GetComponentsInChildren<Rigidbody>();
            _baseColliders = _baseRoot.GetComponents<Collider>();
            _animator = transform.root.GetComponentInChildren<Animator>();
        }

        [ContextMenu(nameof(EnableRagdoll))]
        public void EnableRagdoll()
        {
            if (TryToggleBaseColliders(false) && TryToggleRagdollColliders(false, true))
            {
                _animator.enabled = false;
                OnRagdollEnable?.Invoke();
            }
        }

        [ContextMenu(nameof(DisableRagdoll))]
        public void DisableRagdoll()
        {
            if (TryToggleBaseColliders(true) && TryToggleRagdollColliders(true, false))
            {
                _animator.enabled = true;
                OnRagdollDisable?.Invoke();
            }
        }

        private bool TryToggleRagdollColliders(bool isKinematic, bool collValue)
        {
            if (_ragdollColliders.Length <= 0 || _ragdollBodies.Length <= 0)
            {
                Debug.LogError($"{transform.root.name} can't use ragdoll components, because couldn't found them");
                return false;
            }

            _ragdollBodies.ToList().ForEach(b => b.isKinematic = isKinematic);
            _ragdollColliders.ToList().ForEach(c => c.enabled = collValue);
            return true;
        }

        private bool TryToggleBaseColliders(bool value)
        {
            if (_baseColliders.Length <= 0)
            {
                Debug.LogError($"{transform.root.name} can't use base colliders, because couldn't found them");
                return false;
            }

            _baseColliders.ToList().ForEach(c => c.enabled = value);
            return true;
        }
    }
}