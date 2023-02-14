namespace SSE.Core.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс инфы на поверхности ли
    /// </summary>
    public interface IGroundLocating
    {
        /// <summary>
        /// Состояние, на земле ли
        /// </summary>
        public bool IsOnGround { get; }
    }
}