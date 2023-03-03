using System;
using System.Collections.Generic;
using SSE.Core.Abstractions.Behaviours;
using SSE.Core.Behaviours;
using SSE.Inventory.Abstractions.Controllers;
using SSE.Inventory.Abstractions.Models;
using SSE.Inventory.Abstractions.Views;
using SSE.Inventory.Controllers;
using UnityEngine;

namespace SSE.Inventory.Behaviours
{
    /// <summary>
    /// Фабрика элементов
    /// </summary>
    public class ItemFactory : MonoBehaviour, IFactory<IItemController>
    {
        [SerializeField] private AbstractItemView viewPrefab;
        [SerializeField] private Transform containerViews;
        [Space]
        [SerializeField] private List<AbstractItemModel> models;
        private int _amount;

        private PoolMono<AbstractItemView> _poolViews;

        public void Init(int amount)
        {
            _amount = amount;
            _poolViews = new PoolMono<AbstractItemView>(_amount, viewPrefab, containerViews);
        }

        public IItemController Create(string nameModel, Transform parent = null)
        {
            var model = models.Find(x => x.Name == nameModel);
            if (model != null)
            {
                var item = new ItemController(_poolViews.GetFreeObject(), model);
                if (parent != null)
                    item.SetSlot(parent);
                return item;
            }

            throw new Exception($"Модели с названием {nameModel} не найдено.");
        }
    }
}