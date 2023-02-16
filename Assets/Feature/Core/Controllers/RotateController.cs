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
        [SerializeField] private float minRotate = -180;
        [SerializeField] private float maxRotate = 180;

        private Transform _transform;
        private Vector3 _startRotation;
        private Vector3 _rotation;
        private bool _isStarted;
        
        private void Awake()
        {
            _transform = transform;
            _startRotation = _transform.rotation.eulerAngles;
        }
        
        public void Interact(Vector3 rotation)
        {
            if (_rotation.Equals(rotation))
                return;
            _rotation = rotation;
            Rotate();
        }
        
        private void Rotate()
        {
            var newRotation = (_transform.localRotation * Quaternion.Euler(_rotation * speed)).eulerAngles;
            Debug.LogError(newRotation);
            if (CheckSwivelRange(_startRotation.x, newRotation.x) 
                && CheckSwivelRange(_startRotation.y, newRotation.y)
                && CheckSwivelRange(_startRotation.z, newRotation.z))
            {
                _transform.localRotation *= Quaternion.Euler(_rotation * speed);
            }
        }
        
        private bool CheckSwivelRange(float startRotate, float rotate)
        {
            return startRotate + minRotate <= GetAngle(rotate) && GetAngle(rotate) <= startRotate + maxRotate;
        }

        private float GetAngle(float x)
        {
            return x > 180 ? x - 360f : x ;
        }
    }
}