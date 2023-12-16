using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private readonly int _moveHash = Animator.StringToHash("Speed");

        public void UpdateBlendTree(float value)
        {
            _animator.SetFloat(_moveHash, value);
        }
    }
}