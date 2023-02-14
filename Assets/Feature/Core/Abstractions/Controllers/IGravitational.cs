namespace SSE.Core.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс гравитации
    /// </summary>
    public interface IGravitational : IGroundLocating, IInteractObservable
    {
        /// <summary>
        /// Гравитационная постоянная
        /// </summary>
        public float Gravity { get; }
        
        /// <summary>
        /// Скорость падения
        /// </summary>
        public float Velocity { get; set; }
    }
}