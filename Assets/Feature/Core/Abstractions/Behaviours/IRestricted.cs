using UnityEngine;

namespace SSE.Core.Abstractions.Behaviours
{
    /// <summary>
    /// Интерфейс ограничиваемого
    /// </summary>
    public interface IRestricted
    {
        /// <summary>
        /// Ограничен ли?
        /// </summary>
        public bool IsRestrict { get; }
        
        /// <summary>
        /// Добавить органичение
        /// </summary>
        /// <param name="gameObject">Ссылка на объект, который ограничивает</param>
        public void AddRestriction(GameObject gameObject);
        
        /// <summary>
        /// Убрать органичение
        /// </summary>
        /// <param name="gameObject">Ссылка на объект, которое убирате ограничиние</param>
        public void RemoveRestriction(GameObject gameObject);
    }
}