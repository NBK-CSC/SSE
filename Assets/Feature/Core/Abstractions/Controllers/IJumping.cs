using SSE.Core.Abstractions.Behaviours;
using UnityEngine;

namespace SSE.Core.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс прыжка
    /// </summary>
    public interface IJumping : IInteractObservable
    {
        /// <summary>
        /// Иницилизация
        /// </summary>
        /// <param name="characterController">Контроллер персонажа</param>
        /// <param name="gravitateController">Контроллер гравитации</param>
        /// <param name="surfaceDownDetector">Детектор нижней поверхности</param>
        public void Init(CharacterController characterController, IGravitational gravitateController, ISurfaceDetecting surfaceDownDetector);

        /// <summary>
        /// Прыгнуть
        /// </summary>
        public void Jump();
    }
}