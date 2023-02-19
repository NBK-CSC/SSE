using System.Collections.Generic;
using SSE.Core.Abstractions.Behaviours;
using SSE.Core.Abstractions.Controllers;
using UnityEngine;

namespace SSE.Core.Controllers
{
    /// <summary>
    /// Контроллер ограничений
    /// </summary>
    public class RestrictController : IRestricting
    {
        private readonly IInteractObservable _interactObservable;
        private readonly List<IRestricted> _restricts;
        private readonly GameObject _gameObject;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="interactObservable">Объект оповещающий о взаимодействии</param>
        /// <param name="gameObject">Ссылка на игровой объект который будет ограничивать</param>
        public RestrictController(IInteractObservable interactObservable, GameObject gameObject)
        {
            _interactObservable = interactObservable;
            _gameObject = gameObject;
            _interactObservable.OnInteracted += OnInteract;
            
            _restricts = new List<IRestricted>();
        }

        ~RestrictController()
        {
            _interactObservable.OnInteracted -= OnInteract;
        }

        public void AddRestricts(params IRestricted[] restricts)
        {
            foreach (var r in restricts)
                _restricts.Add(r);
        }

        public void RemoveRestricts(params IRestricted[] restricts)
        {
            foreach (var r in restricts)
            {
                r.RemoveRestriction(_gameObject);
                _restricts.Remove(r);
            }
        }

        private void OnInteract(bool state)
        {
            foreach (var restricted in _restricts)
            {
                if (state)
                    restricted.AddRestriction(_gameObject);
                else
                    restricted.RemoveRestriction(_gameObject);
            }
        }
    }
}