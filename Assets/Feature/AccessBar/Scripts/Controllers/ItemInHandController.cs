using System;
using SSE.AccessBar.Abstractions.Controllers;
using SSE.AccessBar.Abstractions.Views;
using SSE.Core.Behaviours;
using UnityEngine;

namespace SSE.AccessBar.Controllers
{
    /// <summary>
    /// Контроллер элемента в руке
    /// </summary>
    public class ItemInHandController : MonoBehaviour, IItemInHandController
    {
        [SerializeField] private Transform itemInHandPosition;
        [SerializeField] private LayerMask newLayer;
        private Container _objectsContainer;
        private GameObject _currentGameObjectItem;
        private string _currentNameItem;
        
        private GameObject _currentObject;

        public void Init(Container objectsContainer)
        {
            _objectsContainer = objectsContainer;
        }

        public void Choose(string nameObj)
        {
            if (_currentGameObjectItem != null)
            {
                _objectsContainer.Add(_currentNameItem, _currentGameObjectItem);
            }

            if (nameObj == null || !_objectsContainer.TryRemove(nameObj, out var obj)) 
                return;
            _currentGameObjectItem = obj;
            _currentNameItem = nameObj;
            if (!obj.TryGetComponent<IItemInHand>(out var item))
                throw new Exception($"Объекте, который должен взяться в руку, не найден {typeof(IItemInHand)}");
            item.SetContainer(true, itemInHandPosition, Vector3.zero, (int)Math.Log(newLayer.value, 2));
        }
    }
}