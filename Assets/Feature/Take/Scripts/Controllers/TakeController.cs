using SSE.Inventory.Abstractions.Controllers;
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
        [SerializeField] private Transform direction;
        
        private IAdding _addController;

        public void Init(IAdding addController)
        {
            _addController = addController;
        }
        
        public void Take()
        {
            if (_addController.IsFull || 
                !Physics.Raycast(direction.position, direction.TransformDirection(Vector3.forward), out var hit, takeDistance, ~ignoreLayer) || 
                !hit.transform.TryGetComponent<ITaking>(out var takeObj)) 
                return;
            _addController.TryAdd(takeObj.Name, hit.transform.gameObject);
        }
    }
}