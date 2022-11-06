using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NailInTheCoffin.Player
{
    public class ShootState : PlayerState
    {
        public override void Enter()
        {
            base.Enter();
            _stateMachine.AnimationController.PlayShoot();
            _stateMachine.AnimationController.AnimationFinished += OnAnimationFinished;
        }

        public override void Exit()
        {
            base.Exit();
            _stateMachine.AnimationController.AnimationFinished -= OnAnimationFinished;
        }
        
        private void OnAnimationFinished()
        {
            if (_input.IsAimPressed)
                _stateMachine.ChangeState(_stateMachine.AimState);
            else
                _stateMachine.ChangeState(_stateMachine.IdleState);
        }
    }
}
