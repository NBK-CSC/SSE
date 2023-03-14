using UnityEngine;

namespace SSE.Inventory.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс элемента в руке
    /// </summary>
    public interface IHandObject
    {
        /// <summary>
        /// Сделать активным
        /// </summary>
        /// <param name="state">Состоние активности</param>
        public void SetActive(bool state);
        
        /// <summary>
        /// Установить позицию
        /// </summary>
        /// <param name="position">Позиция</param>
        public void SetPosition(Vector3 position);
        
        /// <summary>
        /// Установить родителя
        /// </summary>
        /// <param name="parent">Transform родителя</param>
        public void SetParent(Transform parent);
        
        /// <summary>
        /// Использовать физику
        /// </summary>
        /// <param name="state"></param>
        public void UsePhysic(bool state);
        
        /// <summary>
        /// Установить слой
        /// </summary>
        /// <param name="layer">номер слоя</param>
        public void SetLayer(int layer);
    }
}