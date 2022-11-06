using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NailInTheCoffin.Player
{
    public class PlayerStateMachine : MonoBehaviour
    {
        [Header("States")]
        [SerializeField] private PlayerState _initialState;
        public PlayerState IdleState;
        public PlayerState MoveState;
        public PlayerState AttackState;
        public PlayerState HurtState;
        public PlayerState AimState;
        public PlayerState ShootState;

        [Header("References")]
        [SerializeField] private GameObject _playerGameObject;
        [SerializeField] private GameObject _hurtboxHolder;

        [HideInInspector] public GameplayInput Input;
        [HideInInspector] public Rigidbody2D Rigidbody;
        [HideInInspector] public Animator Animator;
        [HideInInspector] public PlayerAnimationController AnimationController;
        [HideInInspector] public SpriteRenderer SpriteRenderer;
        [HideInInspector] public NailInTheCoffin.Combat.Hurtbox Hurtobx;

        private PlayerState _currentState;
        private PlayerState _lastState;


        private void Awake()
        {
            Input = _playerGameObject.GetComponent<GameplayInput>();
            Rigidbody = _playerGameObject.GetComponent<Rigidbody2D>();
            Animator = _playerGameObject.GetComponent<Animator>();
            AnimationController = _playerGameObject.GetComponent<PlayerAnimationController>();
            SpriteRenderer = _playerGameObject.GetComponentInChildren<SpriteRenderer>();
            Hurtobx = _hurtboxHolder.GetComponentInChildren<NailInTheCoffin.Combat.Hurtbox>();

            var states = GetComponentsInChildren<PlayerState>();
            foreach (var state in states)
                state.Initialize(this);

            _currentState = _initialState;
        }

        private void Start()
        {
            _currentState.Enter();
        }

        private void Update()
        {
            _currentState.Execute();
        }

        private void FixedUpdate()
        {
            _currentState.FixedExecute();
        }


        public void ChangeState(PlayerState newState)
        {
            _currentState.Exit();
            _lastState = _currentState;
            _currentState = newState;
            _currentState.Enter();
        }
    }
}
