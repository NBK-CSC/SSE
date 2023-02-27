using UnityEngine;

namespace SSE.Movement.Rotate.Abstractions.Controller
{
    /// <summary>
    /// Интерфейс поворота
    /// </summary>
    public interface IRotating
    {
        /// <summary>
        /// Повернуть
        /// </summary>
        /// <param name="rotation">Дельта поворота</param>
        public void Rotate(Vector3 rotation);
    }
}