using SSE.AccessBar.Abstractions.Controllers;
using SSE.Core.Behaviours;
using SSE.Take.Abstractions.Controllers;
using UnityEngine;

namespace SSE.Take.Controllers
{
    /// <summary>
    /// Контроллера поднятия
    /// </summary>
    public class TakeController : MonoBehaviour, ITakeController
    {
        [SerializeField] private LayerMask ignoreLayer;
        [SerializeField] private float takeDistance = 10f;
        [SerializeField] private Container container;
        
        private IAddingItem _addController;
        private Transform _transform;

        public Container Container => container;

        public void Init(IAddingItem addController)
        {
            _addController = addController;
            _transform = transform;
        }
        
        public void Take()
        {
            if (_addController.IsFull || 
                !Physics.Raycast(_transform.position, _transform.TransformDirection(Vector3.forward), out var hit, takeDistance, ~ignoreLayer) || 
                !hit.transform.TryGetComponent<ITaking>(out var takeObj)) 
                return;
            container.Add(takeObj.Name, hit.transform.gameObject);
            _addController.TryAdd(takeObj.Name);
        }
    }
}