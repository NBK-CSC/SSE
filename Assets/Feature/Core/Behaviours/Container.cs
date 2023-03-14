using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SSE.Core.Behaviours
{
    /// <summary>
    /// Контейнер
    /// </summary>
    [Serializable]
    public class Container
    {
        [SerializeField] private Transform container;

        private Dictionary<string, List<GameObject>> _dictionary = new ();

        /// <summary>
        /// Добавить элемент
        /// </summary>
        /// <param name="nameObj">Название элемента</param>
        /// <param name="go">Ссылка на GameObject</param>
        public void Add(string nameObj, GameObject go)
        {
            go.SetActive(false);
            go.transform.SetParent(container);
            go.transform.position = Vector3.zero;

            if (_dictionary.ContainsKey(nameObj))
            {
                _dictionary[nameObj].Add(go);
                return;
            }
            _dictionary.Add(nameObj, new List<GameObject>(){ go});
        }

        /// <summary>
        /// Попробовать удалить
        /// </summary>
        /// <param name="nameObj">Имя объекта</param>
        /// <param name="element">Ссылка на удаленный элемент</param>
        /// <returns>Получилось ли удалить?</returns>
        public bool TryRemove(string nameObj, out GameObject element)
        {
            if (_dictionary.ContainsKey(nameObj))
            {
                element = _dictionary[nameObj].First();
                if (_dictionary[nameObj].Count == 0)
                    _dictionary.Remove(nameObj);
                return true;
            }
            element = default;
            return false;
        }
    }
}