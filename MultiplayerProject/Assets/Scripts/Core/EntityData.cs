using UnityEngine;

namespace Entity.Data
{
    public abstract class EntityData : ScriptableObject
    {
        [field: SerializeField] public string NameID { get; private set; }
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}