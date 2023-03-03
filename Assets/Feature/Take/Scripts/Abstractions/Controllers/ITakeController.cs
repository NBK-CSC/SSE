using SSE.Core.Behaviours;
using SSE.Inventory.Abstractions.Controllers;

namespace SSE.Take.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс контроллера поднятия
    /// </summary>
    public interface ITakeController
    {
        /// <summary>
        /// Иницилизация
        /// </summary>
        /// <param name="addController">Контроллер которому можно добавить элемент</param>
        public void Init(IAdding addController);
        
        /// <summary>
        /// Поднять
        /// </summary>
        public void Take();
    }
}