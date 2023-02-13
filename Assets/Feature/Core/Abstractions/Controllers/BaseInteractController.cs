using System;
using UnityEngine;
using UnityEngine.Events;

namespace SSE.Core.Abstractions.Controllers
{
    /// <summary>
    /// Базовый контроллер взаимодействия
    /// </summary>
    public abstract class BaseInteractController: MonoBehaviour
    {
        [SerializeField] protected UnityEvent onStarted;
        [SerializeField] protected UnityEvent onEnded;
        
        public abstract event Action<bool> OnInteracted;
        
        protected virtual void OnEnable()
        {
            OnInteracted += InvokeActions;
        }
        
        protected virtual void OnDisable()
        {
            OnInteracted -= InvokeActions;
        }
        
        private void InvokeActions(bool state)
        {
            if (state)
                onStarted.Invoke();
            else
                onEnded.Invoke();
        } 
    }
}