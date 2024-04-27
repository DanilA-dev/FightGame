using Core.Character;
using CustomFSM.State;
using View;

namespace CharacterFSM
{
    public abstract class BaseCharacterState : IState
    {
        protected CharacterEntity _character;
        protected CharacterView _view;

        public BaseCharacterState(CharacterEntity character, CharacterView view)
        {
            _character = character;
            _view = view;
        }
        
        public virtual void OnEnter() {}
        public virtual void OnUpdate() {}
        public virtual void OnFixedUpdate() {}
        public virtual void OnExit() {}
        
        public abstract float ExitTime { get; }
    }
}