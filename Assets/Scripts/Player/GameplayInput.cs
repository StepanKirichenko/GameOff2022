using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NailInTheCoffin.Player
{
    public class GameplayInput : MonoBehaviour
    {
        public event System.Action AttackPressed;

        public event System.Action AimPressed;
        public event System.Action AimReleased;
        public event System.Action ShootPressed;

        public float Movement { get; private set; }
        public bool IsAimPressed { get; private set; }

        private PlayerInput _playerInput;

        private InputAction _moveAction;
        private InputAction _attackAction;
        private InputAction _aimAction;
        private InputAction _shootAction;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _moveAction = _playerInput.actions["Gameplay/Move"];
            _attackAction = _playerInput.actions["Gameplay/Attack"];
            _aimAction = _playerInput.actions["Gameplay/Aim"];
            _shootAction = _playerInput.actions["Gameplay/Shoot"];
        }

        private void OnEnable()
        {
            _attackAction.started += OnAttackStarted;
            _aimAction.started += OnAimStarted;
            _aimAction.canceled += OnAimCanceled;
            _shootAction.started += OnShootStarted;
        }

        private void OnDisable()
        {
            _attackAction.started -= OnAttackStarted;
            _aimAction.started -= OnAimStarted;
            _aimAction.canceled -= OnAimCanceled;
            _shootAction.started -= OnShootStarted;
        }

        private void Update()
        {
            Movement = _moveAction.ReadValue<float>();
        }


        private void OnAttackStarted(InputAction.CallbackContext context) => AttackPressed?.Invoke();

        private void OnAimStarted(InputAction.CallbackContext context)
        {
            IsAimPressed = true;
            AimPressed?.Invoke();
        }

        private void OnAimCanceled(InputAction.CallbackContext context)
        {
            IsAimPressed = false;
            AimReleased?.Invoke();
        }

        private void OnShootStarted(InputAction.CallbackContext context) => ShootPressed?.Invoke();

    }
}
