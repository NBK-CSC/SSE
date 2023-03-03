using SSE.Inventory.Abstractions.Controllers;
using SSE.Core.Abstractions.Behaviours;
using UnityEngine;

namespace SSE.Inventory.Abstractions.Views
{
    /// <summary>
    /// Абстракция вью инвентаря
    /// </summary>
    public abstract class AbstractInventoryView : MonoBehaviour
    {
        /// <summary>
        /// Иницилизация инвентаря
        /// </summary>
        /// <param name="amountSlots">Количество слотов</param>
        /// <param name="itemFactory">Фабрика эдементов</param>
        /// <param name="slotFactory">Фабрика слотов</param>
        public abstract void Init(int amountSlots, IFactory<IItemController> itemFactory, IFactory<ISlotController> slotFactory);
        
        /// <summary>
        /// Добавить
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="index">Индекс</param>
        public abstract void Add(string name, int index);
        
        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="index">Индекс</param>
        public abstract void Remove(int index);
        
        /// <summary>
        /// Выбрать
        /// </summary>
        /// <param name="index">Индекс</param>
        public abstract void Choose(int index);
    }
}