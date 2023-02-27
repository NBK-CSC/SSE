namespace SSE.AccessBar.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс контроллера слота
    /// </summary>
    public interface ISlotController
    {
        /// <summary>
        /// Имя элемента в слоте
        /// </summary>
        public string ItemName { get; }
        
        /// <summary>
        /// Пустой ли слот?
        /// </summary>
        public bool IsEmpty { get; }
        
        /// <summary>
        /// Активность слота
        /// </summary>
        public bool Active { get; set; }
        
        /// <summary>
        /// Контроллер элемента в ячейке
        /// </summary>
        public IItemController ItemController { get; }

        /// <summary>
        /// Попытаться установить в слот элемент
        /// </summary>
        /// <param name="itemController">Контроллер элемента</param>
        /// <returns>Установили ли элемент?</returns>
        public bool TrySetItem(IItemController itemController);
        
        /// <summary>
        /// Очистить слот
        /// </summary>
        /// <returns>Ссылка на удаленный контроллер элемента</returns>
        public IItemController Clear();
    }
}