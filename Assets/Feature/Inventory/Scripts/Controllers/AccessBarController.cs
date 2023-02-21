using System;
using System.Collections.Generic;
using System.Linq;
using SSE.Core.Behaviours;
using SSE.Inventory.Abstractions.Controllers;
using SSE.Inventory.Abstractions.Models;
using SSE.Inventory.Abstractions.Views;
using UnityEngine;

namespace SSE.Inventory.Controllers
{
    public class AccessBarController : MonoBehaviour, IAccessBar
    {
        [SerializeField] private int amountSlots;
        [SerializeField] private Transform itemViewsContainer;
        [SerializeField] private Transform slotViewsContainer;
        [SerializeField] private Transform inventory;
        [SerializeField] private AbstractItemView itemViewPrefab;
        [SerializeField] private AbstractSlotView slotViewPrefab;
        [Space] 
        [SerializeField] private List<AbstractItemModel> itemModels;

        private ISlotController _lastActiveController;
        private readonly List<ISlotController> _slotControllers = new();
        private PoolMono<AbstractSlotView> _poolMonoSlots;

        public event Action<string> OnItemChosen;

        private void Awake()
        {
            _poolMonoSlots = new PoolMono<AbstractSlotView>(amountSlots, slotViewPrefab, slotViewsContainer);
        }

        private void Start()
        {
            for (uint i = 0; i < amountSlots; i++)
            {
                var slotView = _poolMonoSlots.GetFreeObject();
                slotView.transform.SetParent(inventory);
                _slotControllers.Add(new SlotController(slotView, i + 1));
            }
        }
        
        public bool TryAdd(IItemController controller)
        {
            for (var i = 0; i < amountSlots; i++)
            {
                if (_slotControllers[i].TrySetItem(controller))
                {
                    if (_lastActiveController != null)
                        _lastActiveController.Active = false;
                    _lastActiveController = _slotControllers[i];
                    _lastActiveController.Active = true;
                    return true;
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
                _lastActiveController.Active = false;
            if (_lastActiveController == _slotControllers[number - 1])
            {
                _lastActiveController = null;
                OnItemChosen?.Invoke(null);
                return;
            }
            
            _lastActiveController = _slotControllers[number - 1];
            _lastActiveController.Active = true;
            OnItemChosen?.Invoke(_lastActiveController.ItemName);
        }
    }
}