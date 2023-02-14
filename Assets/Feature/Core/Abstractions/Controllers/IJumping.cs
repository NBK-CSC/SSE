namespace SSE.Core.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс прыжка
    /// </summary>
    public interface IJumping : IInteractObservable
    {
        /// <summary>
        /// Прыжок
        /// </summary>
        public void Jump();
    }
}