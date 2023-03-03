﻿using SSE.Core.Abstractions.Controllers;
using UnityEngine;

namespace SSE.Movement.Move.Abstractions.Controller
{
    /// <summary>
    /// Интерфейс передвижения
    /// </summary>
    public interface IMoving : IInteractObservable, IBoostChangeable, IGetterSpeed
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