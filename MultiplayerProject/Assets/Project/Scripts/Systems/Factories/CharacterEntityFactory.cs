using Core.Character;
using Photon.Pun;
using UnityEngine;

namespace Systems.Factories
{
    public class CharacterEntityFactory : BaseEntityFactory<CharacterEntity>
    {
        public override CharacterEntity Create(CharacterEntity Prefab, Vector3 pos)
        {
            return PhotonNetwork.Instantiate(Prefab.name, pos, Quaternion.identity)
                .GetComponent<CharacterEntity>();
        }
    }
}