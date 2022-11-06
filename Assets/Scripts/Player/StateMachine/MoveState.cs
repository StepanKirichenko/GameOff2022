using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NailInTheCoffin.Player
{
    public class MoveState : PlayerState
    {
        [SerializeField] private float _movementSpeed = 10f;


        public override void Enter()
        {
            base.Enter();
            _stateMachine.AnimationController.PlayMove();
            _input.AttackPressed += OnAttackPressed;
            _input.AimPressed += OnAimPressed;
        }
        
        public override void Exit()
        {
            base.Exit();
            _input.AttackPressed -= OnAttackPressed;
            _input.AimPressed -= OnAimPressed;
        }
        
        public override void FixedExecute()
        {
            base.FixedExecute();
            if (_input.Movement == 0f)
                _stateMachine.ChangeState(_stateMachine.IdleState);

            float movementInput = _input.Movement;

            _stateMachine.AnimationController.SetFacingDirection(movementInput);

            Vector2 position = _stateMachine.transform.position;
            Vector2 movement = Vector2.right * movementInput * _movementSpeed * Time.fixedDeltaTime;
            Vector2 newPosition = position + movement;
            _stateMachine.Rigidbody.MovePosition(newPosition);
        }
        
        private void OnAttackPressed()
        {
            _stateMachine.ChangeState(_stateMachine.AttackState);
        }

        private void OnAimPressed()
        {
            _stateMachine.ChangeState(_stateMachine.AimState);
        }
    }
}
