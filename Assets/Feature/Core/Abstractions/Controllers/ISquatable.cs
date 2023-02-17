using UnityEngine;

namespace SSE.Core.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс приседания
    /// </summary>
    interface ISquatable: IInteractObservable
    {
        /// <summary>
        /// Присесть
        /// </summary>
        public void Squat(IMoving moveController);
        
        /// <summary>
        /// Встать
        /// </summary>
        public void StandUp(IMoving moveController);
    }
}
