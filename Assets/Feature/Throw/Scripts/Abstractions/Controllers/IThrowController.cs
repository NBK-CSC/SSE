using SSE.Inventory.Abstractions.Controllers;
using SSE.Movement.Move.Abstractions.Controller;

namespace SSE.Throw.Abstractions.Controllers
{
    /// <summary>
    /// Интерфейс броска
    /// </summary>
    public interface IThrowController
    {
        /// <summary>
        /// Иницилизация
        /// </summary>
        /// <param name="removing">Контроллер, из которого можно забрать объект</param>
        /// <param name="getterSpeed">Объект, с инфой о текущей скорости</param>
        public void Init(IRemoving removing, IGetterSpeed getterSpeed);
        
        /// <summary>
        /// Выбросить
        /// </summary>
        public void Throw();
    }
}