using UnityEngine;

namespace Entity.Data
{
    [CreateAssetMenu(menuName = "Data/ActorData")]
    public class ActorData : EntityData
    {
        [field: SerializeField] public Color Color { get; private set; }
    }
}