using UnityEngine;

namespace SSE.Core.Abstractions.Controllers
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