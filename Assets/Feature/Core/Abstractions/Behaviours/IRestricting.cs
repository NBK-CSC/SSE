namespace SSE.Core.Abstractions.Behaviours
{
    /// <summary>
    /// Интерфейс объекта который ограничивает другие объекты
    /// </summary>
    public interface IRestricting
    {
        /// <summary>
        /// Добавить объекты, которые можно ограничить
        /// </summary>
        /// <param name="restricts">Ограничиваемые объекты</param>
        public void AddRestricts(params IRestricted[] restricts);

        /// <summary>
        /// Убрать объекты, которые можно ограничить
        /// </summary>
        /// <param name="restricts">Ограничиваемые объекты</param>
        public void RemoveRestricts(params IRestricted[] restricts);
    }
}