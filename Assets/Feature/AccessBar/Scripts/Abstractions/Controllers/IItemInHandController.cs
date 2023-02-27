using SSE.Core.Behaviours;

namespace SSE.AccessBar.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс элемента в рку
    /// </summary>
    public interface IItemInHandController
    {
        /// <summary>
        /// Иницилизация
        /// </summary>
        /// <param name="objectsContainer">Контейнер объектов</param>
        public void Init(Container objectsContainer);

        /// <summary>
        /// Выбрать элемент
        /// </summary>
        /// <param name="nameObj">Имя элемента</param>
        public void Choose(string nameObj);
    }
}