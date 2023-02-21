using UnityEngine;

namespace SSE.Inventory.Abstractions.Models
{
    public interface IItemModel
    {
        /// <summary>
        /// Название предмета в ячейке
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Изображение предмета
        /// </summary>
        public Sprite Sprite { get; }
    }
}