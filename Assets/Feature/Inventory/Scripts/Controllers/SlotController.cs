using SSE.Inventory.Abstractions.Controllers;
using SSE.Inventory.Abstractions.Views;

namespace SSE.Inventory.Controllers
{
    /// <summary>
    /// Контроллер слота
    /// </summary>
    public class SlotController : ISlotController
    {
        private readonly AbstractSlotView _view;

        public bool IsEmpty => ItemController == null;
        public IItemController ItemController { get; private set; }
        public string ItemName => ItemController?.Name;
        
        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        /// <param name="view">Вью слота</param>
        /// <param name="number">Номер слота</param>
        public SlotController(AbstractSlotView view, uint number)
        {
            _view = view;
            _view.NumberSlot = number;
        }
        
        public bool Active
        {
            get => _view.Active;
            set => _view.Active = value;
        }
        
        public bool TrySetItem(IItemController itemController)
        {
            if (!IsEmpty)
                return false;
            ItemController = itemController;
            ItemController.SetSlot(_view.transform);
            return true;
        }

        public IItemController Clear()
        {
            if (IsEmpty)
                return null;
            var item = ItemController;
            ItemController = null;
            Active = false;
            return item;
        }
    }
}