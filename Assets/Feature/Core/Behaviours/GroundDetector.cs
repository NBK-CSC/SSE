using System;
using SSE.Core.Abstractions.Behaviours;
using UnityEngine;

namespace SSE.Core.Behaviours
{
    /// <summary>
    /// Детектор поверхности
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class GroundDetector : MonoBehaviour, IGroundDetecting
    {
        public event Action<bool> OnInteracted;

        private void OnTriggerEnter(Collider other)
        {
            OnInteracted?.Invoke(true);
        } 
        
        private void OnTriggerExit(Collider other)
        {   
            OnInteracted?.Invoke(false);
        } 
    }
}
