using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace NailInTheCoffin.Combat
{
    public class Hurtbox : MonoBehaviour
    {
        public int TeamId;

        public UnityEvent HitDetected;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var hitbox = other.GetComponent<Hitbox>();
            if (hitbox is null)
                return;
            if (hitbox.TeamId != TeamId)
            {
                HitDetected.Invoke();
                print("hit detected");
            }
        }
    }
}
