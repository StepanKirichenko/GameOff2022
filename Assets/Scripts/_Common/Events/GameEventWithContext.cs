using System;
using UnityEngine;
using UnityEngine.Events;

namespace KusogeKenkyuubu.Common
{
    [CreateAssetMenu(fileName = "GameEventWithContext", menuName = "GameEvents/GameEventWithContext")]
    public class GameEventWithContext : GameEvent
    {
        public event Action<GameEventContext> EventWithContext;
        public UnityEvent<GameEventContext> UnityEventWithContext;
        
        public void Raise(GameEventContext context)
        {
            Raise();
            EventWithContext?.Invoke(context);
            UnityEventWithContext.Invoke(context);
        }

        public void Subscribe(Action<GameEventContext> action) => EventWithContext += action;
        public void Unsubscribe(Action<GameEventContext> action) => EventWithContext -= action;
    }
}
