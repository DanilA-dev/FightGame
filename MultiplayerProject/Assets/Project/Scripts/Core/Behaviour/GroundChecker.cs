using UnityEngine;

namespace Core.Behaviour
{
    [System.Serializable]
    public class GroundChecker
    {
        [SerializeField] private float _sphereRadius;
        [SerializeField] private Transform _groundCheckOrigin;
        [SerializeField] private LayerMask _groundLayer;
        
        public bool IsGrounded { get; private set; }

        public void UpdateGroundCheck()
        {
            IsGrounded = Physics.CheckSphere(_groundCheckOrigin.position, _sphereRadius, _groundLayer);
        }

        public void DrawGizmos()
        {
            if(_groundCheckOrigin == null)
                return;

            Color c = IsGrounded ? Color.green : Color.red;
            Gizmos.color = c;
            Gizmos.DrawSphere(_groundCheckOrigin.position, _sphereRadius);
        }
    }
}