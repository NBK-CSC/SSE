using SSE.Inventory.Abstractions.Controllers;
using SSE.Core.Abstractions.Behaviours;
using SSE.Inventory.Abstractions.Views;
using UnityEngine;

namespace SSE.Inventory.Views
{
    /// <summary>
    /// Вью инвентаря
    /// </summary>
    public class InventoryView : AbstractInventoryView
    {
        [SerializeField] private Transform container;
        private int _amountSlots;
        private ISlotController _lastChooseSlot;

        private ISlotController[] _slotControllers;

        private IFactory<IItemController> _itemFactory;
        private IFactory<ISlotController> _slotFactory;

        public override void Init(int amountSlots, IFactory<IItemController> itemFactory, IFactory<ISlotController> slotFactory)
        {
            _amountSlots = amountSlots;
            _itemFactory = itemFactory;
            _slotFactory = slotFactory;

            _slotControllers = new ISlotController[_amountSlots];
            for (var i = 0; i < _amountSlots; i++)
                _slotControllers[i] = _slotFactory.Create($"{i + 1}", container);
        }

        public override void Add(string name, int index)
        {
            _slotControllers[index].TrySetItem(_itemFactory.Create(name));
        }

        public override void Remove(int index)
        {
            _slotControllers[index].Clear().Dispose();
        }

        public override void Choose(int index)
        {
            if (_lastChooseSlot != null)
                _lastChooseSlot.Active = false;
            if (index == -1)
                return;
            _lastChooseSlot = _slotControllers[index];
            _lastChooseSlot.Active = true;
        }
    }
}