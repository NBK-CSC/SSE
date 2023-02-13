using System;

namespace SSE.Core.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс оповещающий о взаимодествии
    /// </summary>
    public interface IInteractObservable
    {
        /// <summary>
        /// Оповещение о взаимодействии
        /// </summary>
        public event Action<bool> OnInteracted;
    }
}