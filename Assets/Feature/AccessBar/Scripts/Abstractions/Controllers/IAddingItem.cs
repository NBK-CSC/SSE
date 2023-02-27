namespace SSE.AccessBar.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс добавления элемента
    /// </summary>
    public interface IAddingItem
    {
        /// <summary>
        /// Полон ли?
        /// </summary>
        public bool IsFull { get; }

        /// <summary>
        /// Попытаться добавить элемент
        /// </summary>
        /// <param name="controller">Контроллер элемента</param>
        /// <returns>Получилось ли добавить?</returns>
        public bool TryAdd(IItemController controller);
        
        /// <summary>
        /// Попытаться добавить элемент
        /// </summary>
        /// <param name="nameItem">Имя элемента которого можно добавить</param>
        /// <returns>Получилось ли добавить?</returns>
        public bool TryAdd(string nameItem);

        /// <summary>
        /// Попытаться добавить элемент
        /// </summary>
        /// <param name="index">Номер слота в который надо поместить элемент</param>
        /// <param name="controller">Контроллер элемента</param>
        /// <returns>Получилось ли добавить?</returns>
        public bool TryAdd(int index, IItemController controller);
    }
}