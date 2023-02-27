using SSE.AccessBar.Abstractions.Controllers;
using SSE.Core.Behaviours;

namespace SSE.Take.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс контроллера поднятия
    /// </summary>
    public interface ITakeController
    {
        /// <summary>
        /// Контейнер со поднятыми объектами
        /// </summary>
        public Container Container { get; }

        /// <summary>
        /// Иницилизация
        /// </summary>
        /// <param name="addController">Контроллер которому можно добавить элемент</param>
        public void Init(IAddingItem addController);
        
        /// <summary>
        /// Поднять
        /// </summary>
        public void Take();
    }
}