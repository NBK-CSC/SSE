using SSE.Core.Abstractions.Controllers;
using System;
using UnityEngine;

namespace SSE.Core.Controllers
{
    /// <summary>
    /// Контроллер бега
    /// </summary>
    public class RunController : BaseInteractController, IRunning
    {
        [SerializeField] private float boostCoef;
        
        public override event Action<bool> OnInteracted;
        
        public void Run(IMoving moveController)
        {
            moveController.AddBoost(boostCoef);
            OnInteracted?.Invoke(true);
        }
        
        public void StopRun(IMoving moveController)
        {
            moveController.RemoveBoost();
            OnInteracted?.Invoke(false);
        }
    }
}
