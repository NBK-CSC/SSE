using System;
using SSE.Core.Abstractions.Behaviours;
using SSE.Core.Behaviours;
using SSE.Inventory.Abstractions.Controllers;
using SSE.Inventory.Abstractions.Views;
using SSE.Inventory.Controllers;
using UnityEngine;

namespace SSE.Inventory.Behaviours
{
    /// <summary>
    /// Фабрика слотов
    /// </summary>
    public class SlotFactory : MonoBehaviour, IFactory<ISlotController>
    {
        [SerializeField] private AbstractSlotView viewPrefab;
        [SerializeField] private Transform containerViews;
        private int _amount;

        private PoolMono<AbstractSlotView> _poolViews;

        public void Init(int amount)
        {
            _amount = amount;
            _poolViews = new PoolMono<AbstractSlotView>(_amount, viewPrefab, containerViews);
        }

        public ISlotController Create(string nameModel, Transform parent = null)
        {
            if (!uint.TryParse(nameModel, out var result) || result > _amount)
                throw new Exception($"Не верно введенное число {nameModel}.");
            
            var view = _poolViews.GetFreeObject();
            if (parent != null)
                view.SetParent = parent;
            return new SlotController(view, result);
        }
    }
}