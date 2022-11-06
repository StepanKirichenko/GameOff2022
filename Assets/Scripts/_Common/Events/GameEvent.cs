using UnityEngine;

namespace KusogeKenkyuubu.Common
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "GameEvents/GameEvent")]
    public class GameEvent : ScriptableObject
    {
        public event System.Action Event;
        public UnityEngine.Events.UnityEvent UnityEvent;

        public void Raise()
        {
            Event?.Invoke();
            UnityEvent.Invoke();
        }

        public void Subscribe(System.Action action) => Event += action;
        public void Unsubscribe(System.Action action) => Event -= action;
    }
}
