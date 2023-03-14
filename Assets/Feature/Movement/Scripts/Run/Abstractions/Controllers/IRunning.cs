using SSE.Core.Abstractions.Controllers;
using SSE.Movement.Move.Abstractions.Controller;

namespace SSE.Movement.Run.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс ускорения
    /// </summary>
    public interface IRunning : IInteractObservable
    {
        /// <summary>
        /// Бег
        /// </summary>
        public void Run(IMoving moveController);
        
        /// <summary>
        /// Перейти на шаг
        /// </summary>
        public void StopRun(IMoving moveController);
    }
}
