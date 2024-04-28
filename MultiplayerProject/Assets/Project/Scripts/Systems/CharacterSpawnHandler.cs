using System;
using Systems.Factories;
using Core.Character;
using UnityEngine;

namespace Systems
{
    public class CharacterSpawnHandler : MonoBehaviour
    {
        [SerializeField] private CharacterEntity _character;
        [SerializeField] private Transform _spawnPoint;

        private CharacterEntityFactory _characterEntityFactory;

        private void Awake()
        {
            _characterEntityFactory = new CharacterEntityFactory();
        }

        public CharacterEntity CreateCharacter()
        {
            return _characterEntityFactory.Create(_character, _spawnPoint.position);
        }
    }
}