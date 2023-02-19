using SSE.Core.Abstractions.Behaviours;

namespace SSE.Core.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс объекта который может быть ограничен
    /// </summary>
    public interface ICanRestrict
    {
        /// <summary>
        /// Свойство ограничения
        /// </summary>
        public IRestricted RestrictProperty { get; }
    }
}