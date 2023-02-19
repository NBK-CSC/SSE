using SSE.Core.Abstractions.Controllers;

namespace SSE.Core.Abstractions.Behaviours
{
    /// <summary>
    /// Интерфейс детектора поверхности
    /// </summary>
    public interface ISurfaceDetecting : IInteractObservable
    {
        /// <summary>
        /// Есть ли соприкосновение с поверхностью
        /// </summary>
        public bool IsOnSurface { get; }
    }
}