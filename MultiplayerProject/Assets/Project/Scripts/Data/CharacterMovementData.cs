using UnityEngine;

namespace Project.Scripts.Data.CharacterStatesContext
{
    [CreateAssetMenu( menuName = "Data/Character Movement Data")]
    public class CharacterMovementData : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public float RotateSpeed { get; private set; }
        [field: SerializeField] public float JumpForce { get; private set; }
        [field: SerializeField] public float JumpDuration { get; private set; }
        [field: SerializeField] public float JumpCooldown { get; private set; }
        [field: SerializeField] public float GravityModifer { get; private set; }
    }
}