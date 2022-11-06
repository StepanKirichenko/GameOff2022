using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NailInTheCoffin.Player
{
    public class IdleState : PlayerState
    {
        public override void Enter()
        {
            base.Enter();
            _stateMachine.AnimationController.PlayIdle();
            _input.AttackPressed += OnAttackPressed;
            _input.AimPressed += OnAimPressed;
        } 
        
        public override void Exit()
        {
            base.Exit();
            _input.AttackPressed -= OnAttackPressed;
            _input.AimPressed -= OnAimPressed;
        }
        
        public override void Execute()
        {
            base.Execute();
            if (_input.Movement != 0f)
                _stateMachine.ChangeState(_stateMachine.MoveState);
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
