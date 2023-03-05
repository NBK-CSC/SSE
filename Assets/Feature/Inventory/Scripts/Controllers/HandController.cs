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
        private IHandObject _handObject;

        /// <summary>
        /// Установить в руку
        /// </summary>
        /// <param name="gameObject">Ссылка на объект</param>
        /// <exception cref="Exception">Ошибка при попытке получить компонент</exception>
        public void SetInHand(GameObject gameObject)
        {
            _gameObject = gameObject;
            if (!_gameObject.TryGetComponent<IHandObject>(out _handObject))
                throw new Exception($"Объекте, который должен взяться в руку, не найден {typeof(IHandObject)}");
            _handObject.SetActive(true);
            _handObject.UsePhysic(false);
            _handObject.SetParent(itemInHandPosition);
            _handObject.SetPosition(Vector3.zero);
            _handObject.SetLayer((int)Math.Log(newLayer.value, 2));
        }

        /// <summary>
        /// Забрать из руки
        /// </summary>
        /// <returns>Ссылка на объект</returns>
        /// <exception cref="Exception">Ошибка, если рука пуста</exception>
        public GameObject GetFromHand()
        {
            _handObject.SetLayer(0);
            if (_gameObject == null)
                throw new Exception($"Нет объекта в рукe");
            return _gameObject;
        }
    }
}