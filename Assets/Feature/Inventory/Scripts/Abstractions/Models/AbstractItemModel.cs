using UnityEngine;

namespace SSE.Inventory.Abstractions.Models
{
    /// <summary>
    /// Абстракция модели ячейки
    /// </summary>
    public abstract class AbstractItemModel : ScriptableObject, IItemModel
    {
        public abstract string Name { get; }
        public abstract Sprite Sprite { get; }
    }
}