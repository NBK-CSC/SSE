namespace SSE.Inventory.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс выбора предмета
    /// </summary>
    public interface IChoosing
    {
        /// <summary>
        /// Выбор предмета
        /// </summary>
        /// <param name="number">Номер ячейки</param>
        public void Choose(int number);
    }
}