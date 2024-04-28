using Core.Type;
using UnityEngine;

namespace Systems.Factories
{
    public abstract class BaseEntityFactory<T> where T : Entity
    {
        public abstract T Create(T Prefab, Vector3 pos);
    }
}