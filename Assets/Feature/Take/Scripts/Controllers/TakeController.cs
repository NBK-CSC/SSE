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
        [SerializeField] private Transform direction;
        
        private IAddingItem _addController;

        public Container Container => container;

        public void Init(IAddingItem addController)
        {
            _addController = addController;
        }
        
        public void Take()
        {
            if (_addController.IsFull || 
                !Physics.Raycast(direction.position, direction.TransformDirection(Vector3.forward), out var hit, takeDistance, ~ignoreLayer) || 
                !hit.transform.TryGetComponent<ITaking>(out var takeObj)) 
                return;
            container.Add(takeObj.Name, hit.transform.gameObject);
            _addController.TryAdd(takeObj.Name);
        }
    }
}