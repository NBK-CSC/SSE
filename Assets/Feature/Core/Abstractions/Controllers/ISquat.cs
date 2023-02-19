using SSE.Core.Abstractions.Behaviours;
using UnityEngine;

namespace SSE.Core.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс приседания
    /// </summary>
    internal interface ISquat: IInteractObservable
    {
        /// <summary>
        /// Иницилизация
        /// </summary>
        /// <param name="characterController">Контроллер персонажа</param>
        /// <param name="surfaceUpDetector">Детектор поверхности сверху</param>
        /// <param name="surfaceDownDetecting">Детектор поверхности снизу</param>
        public void Init(CharacterController characterController, ISurfaceDetecting surfaceUpDetector, ISurfaceDetecting surfaceDownDetecting);
        
        /// <summary>
        /// Присесть
        /// </summary>
        /// <param name="boostChangeable">объект, которому можно поменять скорость</param>
        public void SitDown(IBoostChangeable boostChangeable);
        
        /// <summary>
        /// Встать
        /// </summary>
        /// <param name="boostChangeable">объект, которому можно поменять скорость</param>
        public void StandUp(IBoostChangeable boostChangeable);
    }
}
