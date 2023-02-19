using System;
using System.Collections.Generic;
using SSE.Core.Abstractions.Behaviours;
using UnityEngine;

namespace SSE.Core.Behaviours
{
    /// <summary>
    /// Детектор поверхности
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class SurfaceDetector : MonoBehaviour, ISurfaceDetecting
    {
        [SerializeField] private string inverseTag = "";
        private readonly List<GameObject> _count = new ();
        
        public bool IsOnSurface => _count.Count > 0;

        public event Action<bool> OnInteracted;

        private void OnTriggerEnter(Collider other)
        {
            Detect(other.gameObject, true);
        } 
        
        private void OnTriggerExit(Collider other)
        {
            Detect(other.gameObject, false);
        }

        private void Detect(GameObject go, bool state)
        {
            if (!string.IsNullOrEmpty(inverseTag) && go.CompareTag(inverseTag))
                return;
            if (state)
                _count.Add(go);
            else
                _count.Remove(go);
            OnInteracted?.Invoke(state);
        }
    }
}
