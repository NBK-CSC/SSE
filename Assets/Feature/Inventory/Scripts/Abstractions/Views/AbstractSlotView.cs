﻿using UnityEngine;

namespace SSE.Inventory.Abstractions.Views
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
    }
}