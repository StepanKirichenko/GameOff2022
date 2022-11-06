using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NailInTheCoffin.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        public event System.Action AnimationFinished;

        [SerializeField] private Transform _hitboxHolderTransorm;

        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        private Quaternion _hitobxRotationRight = Quaternion.Euler(0f, 0f, 0f);
        private Quaternion _hitobxRotationLeft = Quaternion.Euler(0f, 0f, 180f);


        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public void PlayIdle() => _animator.SetTrigger("PlayIdle");
        public void PlayMove() => _animator.SetTrigger("PlayMove");
        public void PlayAttack() => _animator.SetTrigger("PlayAttack");
        public void PlayHurt() => _animator.SetTrigger("PlayHurt");
        public void PlayAim() => _animator.SetTrigger("PlayAim");
        public void PlayShoot() => _animator.SetTrigger("PlayShoot");

        public void SetFacingDirection(float movement)
        {
            if (movement > 0f)
            {
                _spriteRenderer.flipX = false;
                _hitboxHolderTransorm.rotation = _hitobxRotationRight;
            }
            if (movement < 0f)
            {
                _spriteRenderer.flipX = true;
                _hitboxHolderTransorm.rotation = _hitobxRotationLeft;
            }
        }

        public void InvokeAnimationFinished()
        {
            AnimationFinished?.Invoke();
        }
    }
}
