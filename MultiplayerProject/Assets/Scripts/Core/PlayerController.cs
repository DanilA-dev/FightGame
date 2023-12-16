using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;

        private PlayerInputSetter _playerInputSetter;
        private Rigidbody _rigidbody;
        private Vector3 _moveDir;

        private void Awake()
        {
            _playerInputSetter = GetComponent<PlayerInputSetter>();
            _playerInputSetter.OnMove += UpdateMoveDirection;
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.freezeRotation = true;
        }

        private void Update()
        {
            RotateToMoveDir();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _rigidbody.velocity = new Vector3(_moveDir.x * _moveSpeed * Time.deltaTime, _moveDir.y, _moveDir.z * _moveSpeed * Time.deltaTime);
        }

        private void RotateToMoveDir()
        {
            if(_moveDir == Vector3.zero)
                return;
            
            Quaternion r = Quaternion.LookRotation(_moveDir, Vector3.up);
            Quaternion rotateTowards = Quaternion.RotateTowards(transform.rotation, r, _rotateSpeed * Time.deltaTime);
            transform.rotation = rotateTowards;
        }

        private void UpdateMoveDirection(Vector2 input)
        {
            _moveDir = input != Vector2.zero ? new Vector3(input.x, 0, input.y) : Vector3.zero;
        }
    }
}