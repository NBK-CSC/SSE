using System;
using System.Collections.Generic;
using System.Linq;
using SSE.AccessBar.Abstractions.Controllers;
using SSE.Core.Abstractions.Behaviours;
using UnityEngine;

namespace SSE.AccessBar.Controllers
{
    /// <summary>
    /// Контроллер 
    /// </summary>
    public class AccessBarController : MonoBehaviour, IAccessBar
    {
        [SerializeField] private int amountSlots;
        [SerializeField] private Transform accessBar;

        private IItemInHandController _itemInHand;
        
        private ISlotController _lastActiveController;
        private readonly List<ISlotController> _slotControllers = new();

        private IFactory<IItemController> _itemFactory;
        private IFactory<ISlotController> _slotFactory;

        public bool IsFull => _slotControllers.Count(x => x.IsEmpty == false) == amountSlots;
        
        public event Action<string> OnItemChosen;

        public void Init(IItemInHandController view, IFactory<ISlotController> slotFactory, IFactory<IItemController> itemFactory)
        {
            _itemInHand = view;

            _itemFactory = itemFactory;
            _slotFactory = slotFactory;
            
            _itemFactory.Init();
            _slotFactory.Init();

            for (uint i = 0; i < amountSlots; i++)
                _slotControllers.Add(_slotFactory.Create($"{i + 1}", accessBar));
        }
        
        public bool TryAdd(int index, IItemController controller)
        {
            return _slotControllers[index].TrySetItem(controller);
        }
        
        public bool TryAdd(IItemController controller)
        {
            for (var i = 0; i < amountSlots; i++)
            {
                if(TryAdd(i, controller))
                    return true;
            }
            return false;
        }
        
        public bool TryAdd(string itemName)
        {
            for (var i = 0; i < amountSlots; i++)
            {
                if (_slotControllers[i].IsEmpty)
                {
                    var item = _itemFactory.Create(itemName);
                    if (TryAdd(item))
                        return true;
                    item.Dispose();
                }
            }
            return false;
        }
        
        public bool TryRemove(out IItemController controller)
        {
            if (_lastActiveController != null)
            {
                controller = _lastActiveController.ItemController;
                _lastActiveController.Active = false;
                return true;
            }

            controller = null;
            return false;
        }
        
        public void Choose(int number)
        {
            if (_lastActiveController != null)
            {
                _lastActiveController.Active = false;
                _itemInHand.Choose(null);
            }

            if (_lastActiveController == _slotControllers[number - 1])
            {
                _lastActiveController = null;
                OnItemChosen?.Invoke(null);
                return;
            }
            
            _lastActiveController = _slotControllers[number - 1];
            _lastActiveController.Active = true;
            _itemInHand.Choose(_lastActiveController.ItemName);
            OnItemChosen?.Invoke(_lastActiveController.ItemName);
        }
    }
}