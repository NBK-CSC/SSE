using SSE.AccessBar.Abstractions.Views;
using SSE.AccessBar.Controllers;
using SSE.Take.Abstractions.Controllers;
using UnityEngine;

namespace SSE.Take.Controllers
{
    /// <summary>
    /// Поднимаемый предмет
    /// </summary>
    [RequireComponent(typeof(ItemInHand))]
    public class TakingObject : MonoBehaviour, ITaking
    {
        [SerializeField] private string nameObj;

        public IItemInHand Item { get; private set; }

        public string Name => nameObj;

        private void Awake()
        {
            Item = GetComponent<IItemInHand>();
        }
    }
}