using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NailInTheCoffin.Player
{
    public class AttackState : PlayerState
    {
        public override void Enter()
        {
            base.Enter();
            _stateMachine.AnimationController.PlayAttack();
            _stateMachine.AnimationController.AnimationFinished += OnAnimationFinished;
        }

        public override void Exit()
        {
            base.Exit();
            _stateMachine.AnimationController.AnimationFinished -= OnAnimationFinished;
        }

        private void OnAnimationFinished()
        {
            _stateMachine.ChangeState(_stateMachine.IdleState);
        }
    }
}
