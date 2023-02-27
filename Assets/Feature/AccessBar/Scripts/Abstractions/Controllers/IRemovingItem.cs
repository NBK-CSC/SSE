namespace SSE.AccessBar.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс удаления элемента
    /// </summary>
    public interface IRemovingItem
    {
        /// <summary>
        /// Попытаться удалить выбранный элемент
        /// </summary>
        /// <param name="controller">Ссылка на удаленный контроллер</param>
        /// <returns>Получилось ли удалить?</returns>
        public bool TryRemove(out IItemController controller);
    }
}