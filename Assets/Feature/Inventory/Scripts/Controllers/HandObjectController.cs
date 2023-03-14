using System.Collections.Generic;
using SSE.Inventory.Abstractions.Controllers;
using UnityEngine;

namespace SSE.Inventory.Controllers
{
    /// <summary>
    /// Элемент в руке
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class HandObjectController : MonoBehaviour, IHandObject
    {
        [SerializeField] private Transform directionInHand;
        
        private Transform _transform;
        private Rigidbody _rigidbody;
        private List<GameObject> _gameObjects;

        private void Awake()
        {
            _transform = transform;
            _rigidbody = GetComponent<Rigidbody>();
            
            var transforms = GetComponentsInChildren<Transform>();
            _gameObjects = new List<GameObject>();
            foreach (var tr in transforms)
                _gameObjects.Add(tr.gameObject);
        }
        
        public void SetActive(bool state)
        {
            gameObject.SetActive(state);
        }

        public void SetPosition(Vector3 position)
        {
            _transform.localPosition = position;
            _transform.localRotation = directionInHand == null ? Quaternion.identity : directionInHand.localRotation;
        }

        public void SetParent(Transform parent)
        {
            _transform.SetParent(parent);
        }

        public void UsePhysic(bool state)
        {
            _rigidbody.useGravity = state;
            _rigidbody.isKinematic = !state;
        }

        public void SetLayer(int layer)
        {
            foreach (var go in _gameObjects)
                go.layer = layer;
        }
    }
}