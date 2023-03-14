using SSE.Inventory.Abstractions.Views;
using UnityEngine;
using UnityEngine.UI;

namespace SSE.Inventory.Views
{
    /// <summary>
    /// Вью слота
    /// </summary>
    public class SlotView : AbstractSlotView
    {
        [SerializeField] private Text numberSlot;
        [SerializeField] private GameObject chooseBg;

        public override uint NumberSlot
        {
            set => numberSlot.text = value.ToString();
        }

        public override bool Active
        {
            get => chooseBg.activeSelf;
            set => chooseBg.SetActive(value);
        }

        public override Transform SetParent
        {
            set => transform.SetParent(value);
        }
    }
}