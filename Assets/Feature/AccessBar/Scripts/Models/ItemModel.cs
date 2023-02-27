using SSE.AccessBar.Abstractions.Models;
using UnityEngine;

namespace SSE.AccessBar.Models
{
    /// <summary>
    /// Модель ячейки
    /// </summary>
    [CreateAssetMenu(menuName = "Inventory/" + nameof(ItemModel), fileName = nameof(ItemModel), order = 51)]
    public class ItemModel : AbstractItemModel
    {
        [SerializeField] private string nameObject;
        [SerializeField] private Sprite sprite;
        
        public override string Name => nameObject;
        public override Sprite Sprite => sprite;
    }
}