using System;
using SSE.AccessBar.Abstractions.Controllers;
using SSE.AccessBar.Abstractions.Views;
using SSE.AccessBar.Controllers;
using SSE.Core.Abstractions.Behaviours;
using SSE.Core.Behaviours;
using UnityEngine;

namespace SSE.AccessBar.Behaviours
{
    /// <summary>
    /// Фабрика слотов
    /// </summary>
    public class SlotFactory : MonoBehaviour, IFactory<ISlotController>
    {
        [SerializeField] private AbstractSlotView viewPrefab;
        [SerializeField] private Transform containerViews;
        [SerializeField] private int amount;

        private PoolMono<AbstractSlotView> _poolViews;

        public void Init()
        {
            _poolViews = new PoolMono<AbstractSlotView>(amount, viewPrefab, containerViews);
        }

        public ISlotController Create(string nameModel, Transform parent = null)
        {
            if (!uint.TryParse(nameModel, out var result) || result > amount)
                throw new Exception($"Не верно введенное число {nameModel}.");
            
            var view = _poolViews.GetFreeObject();
            if (parent != null)
                view.SetParent = parent;
            return new SlotController(view, result);
        }
    }
}