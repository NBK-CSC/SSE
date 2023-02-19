using UnityEngine;

namespace SSE.Core.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс передвижения
    /// </summary>
    public interface IMoving : IInteractObservable, IBoostChangeable
    {
        /// <summary>
        /// Иницилизация
        /// </summary>
        /// <param name="characterController">Контроллер персонажа</param>
        public void Init(CharacterController characterController);

        /// <summary>
        /// Передвинуться
        /// </summary>
        public void Move(Vector3 direction);
    }
}