using SSE.Core.Abstractions.Behaviours;
using UnityEngine;

namespace SSE.Core.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс гравитации
    /// </summary>
    public interface IGravitational : IVelocityChangeable, IInteractObservable
    {
        /// <summary>
        /// Иницилизация
        /// </summary>
        /// <param name="characterController">Контроллер персонажа</param>
        /// <param name="surfaceDownDetector">Детектор нижней поверхности</param>
        public void Init(CharacterController characterController, ISurfaceDetecting surfaceDownDetector);
    }
}