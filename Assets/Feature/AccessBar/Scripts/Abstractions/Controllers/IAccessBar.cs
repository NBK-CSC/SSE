using System;
using SSE.Core.Abstractions.Behaviours;

namespace SSE.AccessBar.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс панели быстрого доступа
    /// </summary>
    public interface IAccessBar : IAddingItem, IRemovingItem
    {
        /// <summary>
        /// Ивент выбора элемента
        /// </summary>
        public event Action<string> OnItemChosen;

        public void Init(IItemInHandController view, IFactory<ISlotController> slotFactory, IFactory<IItemController> itemFactory);
        
        /// <summary>
        /// Выбрать ячейку
        /// </summary>
        /// <param name="number">Номер ячейки</param>
        public void Choose(int number);
    }
}