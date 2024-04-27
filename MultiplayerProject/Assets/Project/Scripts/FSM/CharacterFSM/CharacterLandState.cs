using Core.Character;
using UnityEngine;
using View;

namespace CharacterFSM
{
    public class CharacterLandState : BaseCharacterState
    {
        public override float ExitTime => 0.5f;
        
        public CharacterLandState(CharacterEntity character, CharacterView view) : base(character, view)
        {
        }

        public override void OnEnter()
        {
            Debug.Log("Enter Land State");
            _view.Land();
        }

    }
}