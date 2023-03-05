using UnityEngine;

namespace SSE.Throw.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс выбрасываемого объекта
    /// </summary>
    public interface IThrowing
    {
        /// <summary>
        /// Выбросить меня
        /// </summary>
        /// <param name="force">Сила с которой выбрасывают</param>
        public void ThrowMe(Vector3 force);
    }
}