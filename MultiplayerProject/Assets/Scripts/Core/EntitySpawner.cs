using System;
using System.Collections.Generic;
using UnityEngine;
using Extensions;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Player
{
    public class EntitySpawner : MonoBehaviour
    {
        [System.Serializable]
        public class EntitySpanwData
        {
            [field: SerializeField] public GameObject GameObject { get; private set; }
            [field: SerializeField] public Transform SpawnPoint { get; private set; }
            [field: SerializeField] public Color GizmoColor { get; private set; }
        }

        [SerializeField] private bool _spawnAllOnAwake;
        [SerializeField] private List<EntitySpanwData> _spanwDatas = new List<EntitySpanwData>();
        [Header("Debug")]
        [SerializeField] private bool _enableGizmo;
        [SerializeField] private float _gizmoSize = 1;

        public event Action OnPlayerSpawn; 

        private void Awake()
        {
           if(_spawnAllOnAwake)
               SpawnEntities();
           
           OnPlayerSpawn?.Invoke();
        }

        private void SpawnEntities()
        {
            foreach (var t in _spanwDatas)
            {
                var newEntity = Instantiate(t.GameObject);
                newEntity.transform.position = t.SpawnPoint.position;
            }
            
        }

        private void OnDrawGizmos()
        {
            if(!_enableGizmo)
                return;
            
            if(_spanwDatas.Count <= 0)
                return;

            for (int i = 0; i < _spanwDatas.Count; i++)
            {
                Gizmos.color = _spanwDatas[i].GizmoColor;
                if (_spanwDatas[i].SpawnPoint != null)
                {
                    Gizmos.DrawSphere(_spanwDatas[i].SpawnPoint.position, _gizmoSize);
                    var name = _spanwDatas[i].GameObject == null ? "" : _spanwDatas[i].GameObject.name;
                    var guiyStyle = new GUIStyle()
                    {
                        fontSize = 30,
                        
                    };
                    Handles.Label(_spanwDatas[i].SpawnPoint.position.With(y: 3f), name, guiyStyle);
                }
            }
        }
    }
}