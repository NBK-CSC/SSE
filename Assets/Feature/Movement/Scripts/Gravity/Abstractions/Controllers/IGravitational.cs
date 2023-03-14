using SSE.Core.Abstractions.Behaviours;
using SSE.Core.Abstractions.Controllers;
using SSE.Movement.Gravity.Controllers;
using UnityEngine;

namespace SSE.Movement.Gravity.Abstractions.Controllers
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