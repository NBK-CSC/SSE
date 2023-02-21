using SSE.Inventory.Abstractions.Views;
using UnityEngine;
using UnityEngine.UI;

namespace SSE.Inventory.Views
{
    /// <summary>
    /// Вью элемента
    /// </summary>
    public class ItemView : AbstractItemView
    {
        [SerializeField] private Image image;

        private Vector2 _startPosition;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public override Sprite Sprite 
        {
            set => image.sprite = value;
        }

        public override Transform SetSlot
        {
            set
            {
                _transform.SetParent(value);
                _transform.localPosition = Vector3.zero;
            }
        }

        public override void Dispose()
        {
            gameObject.SetActive(false);
        }
    }
}