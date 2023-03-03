using SSE.Inventory.Abstractions.Controllers;
using SSE.Inventory.Abstractions.Models;
using SSE.Inventory.Abstractions.Views;
using UnityEngine;

namespace SSE.Inventory.Controllers
{
    /// <summary>
    /// Контроллер элемента
    /// </summary>
    public class ItemController : IItemController
    {
        private readonly AbstractItemView _view;
        private readonly IItemModel _model;

        public string Name => _model.Name;
        
        public Sprite Sprite => _model.Sprite;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="view">Вью элемента</param>
        /// <param name="model">Модель элемента</param>
        public ItemController(AbstractItemView view, IItemModel model)
        {
            _view = view;
            _model = model;

            _view.Sprite = _model.Sprite;
        }

        public void SetSlot(Transform transformSlot)
        {
            _view.SetSlot = transformSlot;
        }
        
        public void Dispose()
        {
            _view.Dispose();
        }
    }
}