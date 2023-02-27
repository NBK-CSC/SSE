using SSE.AccessBar.Abstractions.Views;

namespace SSE.Take.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс поднимаемого предмента
    /// </summary>
    public interface ITaking
    {
        /// <summary>
        /// Имя предмета
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Ссылка на элемент
        /// </summary>
        public IItemInHand Item { get; }
    }
}