using UnityEngine;

namespace View
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private readonly int _moveHash = Animator.StringToHash("Speed");
        private readonly int _jumpHash = Animator.StringToHash("Jump");
        private readonly int _airHash = Animator.StringToHash("Air");
        private readonly int _landHash = Animator.StringToHash("Land");

        public void UpdateMovementParameter(float moveDelta) => _animator.SetFloat(_moveHash, moveDelta);

        public void Jump() => _animator.SetTrigger(_jumpHash);
        public void InAir() => _animator.SetTrigger(_airHash);
        public void Land() => _animator.SetTrigger(_landHash);
    }
}