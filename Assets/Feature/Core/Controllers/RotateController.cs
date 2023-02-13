using SSE.Core.Abstractions.Controllers;
using UnityEngine;

namespace SSE.Core.Controllers
{
    /// <summary>
    /// Контроллер поворота
    /// </summary>
    public class RotateController : MonoBehaviour, IRotating
    {
        [SerializeField] private float speed = 2f;
                
        private Vector3 _rotation;
        private bool _isStarted;
        
        private void Update()
        {
            Rotate();
        }
        
        public void Interact(Vector3 component)
        {
            if (_rotation.Equals(component))
                return;
            _rotation = component;
        }
        
        private void Rotate()
        {
            transform.localRotation = Quaternion.Euler(_rotation * speed);
        }
    }
}