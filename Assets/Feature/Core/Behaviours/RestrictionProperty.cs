using System.Collections.Generic;
using SSE.Core.Abstractions.Behaviours;
using UnityEngine;

namespace SSE.Core.Behaviours
{
    /// <summary>
    /// Реактивное свойство
    /// </summary>
    public class RestrictionProperty : IRestricted
    {
        private readonly List<GameObject> _gameObjects = new();

        public bool IsRestrict => _gameObjects.Count > 0;

        public void AddRestriction(GameObject gameObject)
        {
            if (_gameObjects.Contains(gameObject))
                return;
            _gameObjects.Add(gameObject);
        }

        public void RemoveRestriction(GameObject gameObject)
        {
            if (!_gameObjects.Contains(gameObject))
                return;
            _gameObjects.Remove(gameObject);
        }
    }
}