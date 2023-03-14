namespace SSE.Inventory.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс инвентаря
    /// </summary>
    public interface IInventory : IAdding, IRemoving, IChoosing
    {
        /// <summary>
        /// Иницилизация
        /// </summary>
        public void Init();
    }
}