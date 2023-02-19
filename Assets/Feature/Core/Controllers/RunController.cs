using SSE.Core.Abstractions.Controllers;
using System;
using SSE.Core.Abstractions.Behaviours;
using SSE.Core.Behaviours;
using UnityEngine;

namespace SSE.Core.Controllers
{
    /// <summary>
    /// Контроллер бега
    /// </summary>
    public class RunController : BaseInteractController, IRunning, ICanRestrict
    {
        [SerializeField] private float boostCoef;
        
        public IRestricted RestrictProperty { get; } = new RestrictionProperty();

        public override event Action<bool> OnInteracted;
        
        public void Run(IMoving moveController)
        {
            if (RestrictProperty.IsRestrict)
                return;
            moveController.AddBoost(boostCoef);
            OnInteracted?.Invoke(true);
        }
        
        public void StopRun(IMoving moveController)
        {
            if (RestrictProperty.IsRestrict)
                return;
            moveController.RemoveBoost();
            OnInteracted?.Invoke(false);
        }
    }
}
