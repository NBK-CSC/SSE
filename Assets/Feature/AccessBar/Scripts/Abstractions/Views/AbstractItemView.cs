using UnityEngine;

namespace SSE.AccessBar.Abstractions.Views
{
    /// <summary>
    /// Абстрактный класс вью элемента
    /// </summary>
    public abstract class AbstractItemView : MonoBehaviour, IItemView
    {
        public abstract Sprite Sprite { set; }
        public abstract Transform SetSlot { set; }
        public abstract void Dispose();
    }
}