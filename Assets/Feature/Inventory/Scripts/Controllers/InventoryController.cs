using SSE.Inventory.Behaviours;
using SSE.Core.Behaviours;
using SSE.Inventory.Abstractions.Controllers;
using SSE.Inventory.Abstractions.Views;
using UnityEngine;

namespace SSE.Inventory.Controllers
{
    /// <summary>
    /// Контроллер инвентаря
    /// </summary>
    public class InventoryController : MonoBehaviour, IInventory
    {
        [SerializeField] private int maxAmount;
        [SerializeField] private AbstractInventoryView view;
        [SerializeField] private SlotFactory slotFactory;
        [SerializeField] private ItemFactory itemFactory;
        [SerializeField] private Container container;
        [SerializeField] private HandController handController;

        private string[] _objects;
        private int _chooseObject = -1;
        private int _amount;

        public bool IsFull => _amount == maxAmount;

        public void Init()
        {
            slotFactory.Init(maxAmount);
            itemFactory.Init(maxAmount);
            view.Init(maxAmount, itemFactory, slotFactory);
            _objects = new string[maxAmount];
        }
        
        public bool TryAdd(string name, GameObject gameObject)
        {
            if (IsFull)
                return false;
            for (var i = 0; i < maxAmount; i++)
            {
                if (_objects[i] == null)
                {
                    _amount++;
                    _objects[i] = name;
                    container.Add(name, gameObject);
                    view.Add(name, i);
                    return true;
                }
            }

            return false;
        }

        public bool TryRemove(out GameObject gameObject)
        {
            if (_chooseObject == -1)
            {
                gameObject = null;
                return false;
            }

            gameObject = handController.GetFromHand();
            _objects[_chooseObject] = null;
            view.Remove(_chooseObject);
            _chooseObject = -1;
            return true;
        }

        public void Choose(int number)
        {
            if (number < 1 || number > maxAmount)
                return;
            if (_chooseObject != -1)
                GetFromHand();
            if (_chooseObject == number - 1)
                _chooseObject = -1;
            else
                SetInHand(number - 1);
            view.Choose(_chooseObject);
        }

        private void SetInHand(int index)
        {
            _chooseObject = index;
            if (_objects[_chooseObject] != null && container.TryRemove(_objects[_chooseObject], out var obj))
                handController.SetInHand(obj);
        }

        private void GetFromHand()
        {
            if (_objects[_chooseObject]!=null)
                container.Add(_objects[_chooseObject], handController.GetFromHand());
        }
    }
}