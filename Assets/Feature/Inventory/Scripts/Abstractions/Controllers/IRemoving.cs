using UnityEngine;

namespace SSE.Inventory.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс удаления объекта
    /// </summary>
    public interface IRemoving
    {
        /// <summary>
        /// Попытаться удалить
        /// </summary>
        /// <param name="gameObject">Ссылка на удаленный объект</param>
        /// <returns>Получилось ли удалить?</returns>
        public bool TryRemove(out GameObject gameObject);
    }
}