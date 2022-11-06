using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NailInTheCoffin.Player
{
    public class AimState : PlayerState
    {
        public override void Enter()
        {
            base.Enter();
            _stateMachine.AnimationController.PlayAim();
            _input.ShootPressed += OnShootPressed;
            _input.AimReleased += OnAimReleased;
        }

        public override void Exit()
        {
            base.Exit();
            _input.ShootPressed -= OnShootPressed;
            _input.AimReleased -= OnAimReleased;
        }
        
        private void OnShootPressed()
        {
            _stateMachine.ChangeState(_stateMachine.ShootState);
        }

        private void OnAimReleased()
        {
            _stateMachine.ChangeState(_stateMachine.IdleState);
        }
    }
}
