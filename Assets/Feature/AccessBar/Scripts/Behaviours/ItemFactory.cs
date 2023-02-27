using System;
using System.Collections.Generic;
using SSE.AccessBar.Abstractions.Controllers;
using SSE.AccessBar.Abstractions.Models;
using SSE.AccessBar.Abstractions.Views;
using SSE.AccessBar.Controllers;
using SSE.Core.Abstractions.Behaviours;
using SSE.Core.Behaviours;
using UnityEngine;

namespace SSE.AccessBar.Behaviours
{
    /// <summary>
    /// Фабрика элементов
    /// </summary>
    public class ItemFactory : MonoBehaviour, IFactory<IItemController>
    {
        [SerializeField] private AbstractItemView viewPrefab;
        [SerializeField] private Transform containerViews;
        [SerializeField] private int amount;
        [Space]
        [SerializeField] private List<AbstractItemModel> models;

        private PoolMono<AbstractItemView> _poolViews;

        public void Init()
        {
            _poolViews = new PoolMono<AbstractItemView>(amount, viewPrefab, containerViews);
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