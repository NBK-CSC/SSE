using System.Collections.Generic;
using SSE.AccessBar.Abstractions.Views;
using UnityEngine;

namespace SSE.AccessBar.Controllers
{
    /// <summary>
    /// Элемент в руке
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class ItemInHand : MonoBehaviour, IItemInHand
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

        public void SetContainer(bool state, Transform parent, Vector3 position, int layer)
        {
            gameObject.SetActive(state);
            foreach (var go in _gameObjects)
                go.layer = layer;
            
            _rigidbody.useGravity = false;
            _rigidbody.isKinematic = true;
            _transform.SetParent(parent);
            _transform.localPosition = position;
            _transform.localRotation = directionInHand == null ? Quaternion.identity : directionInHand.localRotation;
        }
    }
}