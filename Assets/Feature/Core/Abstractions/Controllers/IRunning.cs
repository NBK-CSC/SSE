namespace SSE.Core.Abstractions.Controllers
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
