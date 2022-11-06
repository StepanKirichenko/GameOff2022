using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NailInTheCoffin.Player
{
    public class HurtState : PlayerState
    {
        public override void Enter()
        {
            base.Enter();
            _stateMachine.AnimationController.PlayHurt();
            _stateMachine.AnimationController.AnimationFinished += OnAnimationFinished;
        }
        
        public override void Exit()
        {
            _stateMachine.AnimationController.AnimationFinished -= OnAnimationFinished;
        }
        
        private void OnAnimationFinished()
        {
            _stateMachine.ChangeState(_stateMachine.IdleState);
        }
    }
}
