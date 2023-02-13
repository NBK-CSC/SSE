namespace SSE.Core.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс взаимодествия
    /// </summary>
    public interface IInteractable <in T>
    {
        /// <summary>
        /// Взаимодествовать
        /// </summary>
        /// <param name="component">Комнонент, с которым взаимодействовать</param>
        public void Interact(T component);
    }
}