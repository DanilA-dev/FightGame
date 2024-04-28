using CharacterFSM;
using Core.Behaviour;
using Core.Interfaces;
using Core.Type;
using CustomFSM.Preicate;
using CustomFSM.StateMachine;
using Extensions;
using Project.Scripts.Data.CharacterStatesContext;
using UnityEngine;
using View;

namespace Core.Character
{
    [RequireComponent(typeof(Rigidbody))]
    public class CharacterEntity : Entity
    {
        [SerializeField] private CharacterMovementData _movementData;
        [SerializeField] private CharacterView _view;
        [SerializeField] private GroundChecker _groundChecker;
        
        private IMover _mover;
        
        private StateMachine _stateMachine;
        private CharacterIdleState _idleState;
        private CharacterMoveState _moveState;
        private CharacterJumpState _jumpState;
        private CharacterInAirState _airState;
        private CharacterLandState _landState;

        private Rigidbody _rigidbody;
        private Vector3 _moveDir;
        private void Awake()
        {
            if(!photonView.IsMine)
                return;
            
            _rigidbody = GetComponent<Rigidbody>();
            Init();
        }

        public void Init()
        {
            _stateMachine = new StateMachine();
            _mover = new CharacterRigidBodyMover(_rigidbody);
            
            InitStates();
            InitTransitions();
        }
        

        #region Init States

        private void InitStates()
        {
            _idleState = new CharacterIdleState(this, _view);
            _moveState = new CharacterMoveState(this, _view, _movementData, _mover);
            _jumpState = new CharacterJumpState(this, _view, _movementData, _mover);
            _airState = new CharacterInAirState(this, _view, _movementData, _mover);
            _landState = new CharacterLandState(this, _view);
        }

        private void InitTransitions()
        {
            _stateMachine.AddTransition(_idleState, _moveState, new FuncPredicate(MovePredicate));
            _stateMachine.AddTransition(_moveState, _idleState, new FuncPredicate(IdlePredicate));
            _stateMachine.AddTransition(_idleState, _jumpState, new FuncPredicate(JumpPredicate));
            _stateMachine.AddTransition(_moveState, _jumpState, new FuncPredicate(JumpPredicate));
            _stateMachine.AddTransition(_idleState, _airState, new FuncPredicate(() => !_groundChecker.IsGrounded));
            _stateMachine.AddTransition(_moveState, _airState, new FuncPredicate(() => !_groundChecker.IsGrounded));
            _stateMachine.AddTransition(_jumpState, _airState, new FuncPredicate(() => !_jumpState.JumpTimer.IsRunning));
            _stateMachine.AddTransition(_airState, _landState, new FuncPredicate(() => _groundChecker.IsGrounded));
            _stateMachine.AddTransition(_landState, _idleState, new FuncPredicate(IdlePredicate));
            _stateMachine.AddTransition(_landState, _moveState, new FuncPredicate(MovePredicate));
            _stateMachine.SetState(_idleState);
        }
        
        #endregion

        private void Update()
        {
            if(!photonView.IsMine)
                return;
            
            _stateMachine.OnUpdate();
        }

        private void FixedUpdate()
        {
            if(!photonView.IsMine)
                return;
            
            _stateMachine.OnFixedUpdate();
            _groundChecker.UpdateGroundCheck();
        }

        public void HandleMovementVector(Vector2 input)
        {
            if(!photonView.IsMine)
                return;
            
            _moveDir = new Vector3(input.x, 0, input.y);
            _mover.Direction = _moveDir;
        }

        public void HandleJump()
        {
            if(!photonView.IsMine)
                return;
            
            _jumpState.JumpTimer.Start();
        }

        public void HandleInputRotation(float rotateSpeed)
        {
            if(!photonView.IsMine)
                return;
            
            if(_moveDir == Vector3.zero)
                return;
            
            transform.RotateTowards(_moveDir, Vector3.up, rotateSpeed);
        }
        

        #region States Transitions Predicates

        private bool MovePredicate() => _moveDir != Vector3.zero && _groundChecker.IsGrounded;

        private bool IdlePredicate() => _moveDir == Vector3.zero && _groundChecker.IsGrounded;

        private bool JumpPredicate() => _groundChecker.IsGrounded && _jumpState.JumpTimer.IsRunning;

        #endregion

        #region Gizmos

        private void OnDrawGizmosSelected() => _groundChecker.DrawGizmos();

        #endregion
        
    }
}