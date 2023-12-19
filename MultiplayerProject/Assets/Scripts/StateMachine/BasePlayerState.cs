using Player;

namespace CustomFSM.State
{
    public abstract class BasePlayerState : IState
    {
        protected PlayerController _playerController;
        protected PlayerView _playerView;

        protected BasePlayerState(PlayerController playerController, PlayerView playerView)
        {
            _playerController = playerController;
            _playerView = playerView;
        }

        public void OnEnter()
        {
        }

        public void OnUpdate()
        {
        }

        public void OnFixedUpdate()
        {
        }

        public void OnExit()
        {
        }
    }
}