using System;

namespace SSE.Inventory.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс панели быстрого доступа
    /// </summary>
    public interface IAccessBar
    {
        /// <summary>
        /// Ивент выбора элемента
        /// </summary>
        public event Action<string> OnItemChosen;
        
        /// <summary>
        /// Попытаться добавить элемент
        /// </summary>
        /// <param name="controller">Контроллер элемента</param>
        /// <returns>Получилось ли добавить?</returns>
        public bool TryAdd(IItemController controller);

        /// <summary>
        /// Попытаться удалить выбранный элемент
        /// </summary>
        /// <param name="controller">Ссылка на удаленный контроллер</param>
        /// <returns>Получилось ли удалить?</returns>
        public bool TryRemove(out IItemController controller);

        /// <summary>
        /// Выбрать ячейку
        /// </summary>
        /// <param name="number">Номер ячейки</param>
        public void Choose(int number);
    }
}