using System;
using UnityEngine;

namespace SSE.AccessBar.Abstractions.Views
{
    /// <summary>
    /// Вью элемента
    /// </summary>
    public interface IItemView : IDisposable
    {
        /// <summary>
        /// Изображение элемента
        /// </summary>
        public Sprite Sprite { set; }
        
        /// <summary>
        /// Установить в ячейку
        /// </summary>
        public Transform SetSlot { set; }
    }
}