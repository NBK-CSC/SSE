using UnityEngine;

namespace SSE.Core.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс ускорения
    /// </summary>
    interface IRunning: IInteractObservable
    {
        /// <summary>
        /// Бег
        /// </summary>
        public void Run(IMoving moveController);
        public void StopRun(IMoving moveController);
    }
}
