using System;
using SSE.Inventory.Abstractions.Controllers;
using UnityEngine;

namespace SSE.Inventory.Controllers
{
    /// <summary>
    /// Контроллер руки
    /// </summary>
    public class HandController : MonoBehaviour
    {
        [SerializeField] private Transform itemInHandPosition;
        [SerializeField] private LayerMask newLayer;
        
        private GameObject _gameObject;

        /// <summary>
        /// Установить в руку
        /// </summary>
        /// <param name="gameObject">Ссылка на объект</param>
        /// <exception cref="Exception">Ошибка при попытке получить компонент</exception>
        public void SetInHand(GameObject gameObject)
        {
            _gameObject = gameObject;
            if (!_gameObject.TryGetComponent<IHandObject>(out var handObject))
                throw new Exception($"Объекте, который должен взяться в руку, не найден {typeof(IHandObject)}");
            
            handObject.SetActive(true);
            handObject.UsePhysic(false);
            handObject.SetParent(itemInHandPosition);
            handObject.SetPosition(Vector3.zero);
            handObject.SetLayer((int)Math.Log(newLayer.value, 2));
        }

        /// <summary>
        /// Забрать из руки
        /// </summary>
        /// <returns>Ссылка на объект</returns>
        /// <exception cref="Exception">Ошибка, если рука пуста</exception>
        public GameObject GetFromHand()
        {
            if (_gameObject == null)
                throw new Exception($"Нет объекта в рукe");
            return _gameObject;
        }
    }
}