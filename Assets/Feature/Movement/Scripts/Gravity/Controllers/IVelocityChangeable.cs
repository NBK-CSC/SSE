namespace SSE.Movement.Gravity.Controllers
{
    /// <summary>
    /// Интерфейс изменения скорости
    /// </summary>
    public interface IVelocityChangeable
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