using UnityEngine;

namespace SSE.AccessBar.Abstractions.Views
{
    /// <summary>
    /// Интерфейс элемента в руке
    /// </summary>
    public interface IItemInHand
    {
        /// <summary>
        /// Установить контейнер
        /// </summary>
        /// <param name="state">Состояние активности</param>
        /// <param name="parent">Трансформ родителя</param>
        /// <param name="position">Позиция</param>
        /// <param name="layer">Слоя отображения</param>
        public void SetContainer(bool state, Transform parent, Vector3 position, int layer);
    }
}