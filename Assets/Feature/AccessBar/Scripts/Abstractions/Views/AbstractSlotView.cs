using UnityEngine;

namespace SSE.AccessBar.Abstractions.Views
{
    /// <summary>
    /// Абстракций вью ячейки
    /// </summary>
    public abstract class AbstractSlotView : MonoBehaviour
    {
        /// <summary>
        /// Номер слота
        /// </summary>
        public abstract uint NumberSlot { set; }

        /// <summary>
        /// Активность слота
        /// </summary>
        public abstract bool Active { get; set; }

        /// <summary>
        /// Установить родителя
        /// </summary>
        public abstract Transform SetParent { set; }
    }
}