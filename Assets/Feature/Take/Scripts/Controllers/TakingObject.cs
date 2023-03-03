using SSE.Take.Abstractions.Controllers;
using UnityEngine;

namespace SSE.Take.Controllers
{
    /// <summary>
    /// Поднимаемый предмет
    /// </summary>
    public class TakingObject : MonoBehaviour, ITaking
    {
        [SerializeField] private string nameObj;

        public string Name => nameObj;
    }
}