using UnityEngine;

namespace SSE.Inventory.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс добавления предмета
    /// </summary>
    public interface IAdding
    {
        /// <summary>
        /// Полон ли?
        /// </summary>
        public bool IsFull { get; }

        /// <summary>
        /// Добавить предмет
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="gameObject">Ссылка на игровой объект</param>
        /// <returns>Получилось ли добавить?</returns>
        public bool TryAdd(string name, GameObject gameObject);
    }
}