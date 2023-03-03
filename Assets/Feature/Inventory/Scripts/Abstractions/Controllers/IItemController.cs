using System;
using UnityEngine;

namespace SSE.Inventory.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс контроллера элемента
    /// </summary>
    public interface IItemController : IDisposable
    {
        /// <summary>
        /// Название элемента
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Изображение элемента
        /// </summary>
        public Sprite Sprite { get; }

        /// <summary>
        /// Установить слот
        /// </summary>
        /// <param name="transformSlot">Tranform слота</param>
        public void SetSlot(Transform transformSlot);
    }
}