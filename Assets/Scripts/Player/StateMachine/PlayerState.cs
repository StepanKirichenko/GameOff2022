using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NailInTheCoffin.Player
{
    public abstract class PlayerState : MonoBehaviour
    {
        protected PlayerStateMachine _stateMachine;
        protected GameplayInput _input;

        public virtual void Initialize(PlayerStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _input = _stateMachine.Input;
        }

        public virtual void Enter()
        {
            _stateMachine.Hurtobx.HitDetected.AddListener(OnPlayerHurt);
        }

        public virtual void Exit()
        {
            _stateMachine.Hurtobx.HitDetected.RemoveListener(OnPlayerHurt);
        }

        public virtual void Execute() { }
        public virtual void FixedExecute() { }

        protected void OnPlayerHurt()
        {
            _stateMachine.ChangeState(_stateMachine.HurtState);
        }
    }
}
