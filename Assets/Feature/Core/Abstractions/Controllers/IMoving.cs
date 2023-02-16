using UnityEngine;

namespace SSE.Core.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс передвижения
    /// </summary>
    public interface IMoving : IInteractable<Vector2>, IInteractObservable
    {
        /// <summary>
        /// Добавить буст к передвижению
        /// </summary>
        /// <param name="boost">Значение на сколько должна измениться скорость</param>
        public void AddBoost(float boost);

        /// <summary>
        /// Убрать буст
        /// </summary>
        public void RemoveBoost();
    }
}