using SSE.Throw.Abstractions.Controllers;
using UnityEngine;

namespace SSE.Throw.Controllers
{
    /// <summary>
    /// Объекта, который бросают
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class ThrowingObject : MonoBehaviour, IThrowing
    {
        private Rigidbody _rigidbody;
        private Transform _transform;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _transform = transform;
        }
        
        public void ThrowMe(Vector3 force)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = true;
            _transform.SetParent(null);
            _rigidbody.AddForce(force);
        }
    }
}