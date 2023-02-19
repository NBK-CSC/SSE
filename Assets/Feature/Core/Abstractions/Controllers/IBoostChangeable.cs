namespace SSE.Core.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс изменения буста к скорости
    /// </summary>
    public interface IBoostChangeable
    {
        /// <summary>
        /// Добавить буст к передвижению
        /// </summary>
        /// <param name="boost">Значение на сколько должна измениться скорость</param>
        public void AddBoost(float boost);

        /// <summary>
        /// Убрать буст
        /// </summary>
        public void RemoveBoost();
    }
}