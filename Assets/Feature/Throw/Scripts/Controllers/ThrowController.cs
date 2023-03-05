using System;
using SSE.Inventory.Abstractions.Controllers;
using SSE.Movement.Move.Abstractions.Controller;
using SSE.Throw.Abstractions.Controllers;
using UnityEngine;

namespace SSE.Throw.Controllers
{
    /// <summary>
    /// Контроллер броска
    /// </summary>
    public class ThrowController : MonoBehaviour, IThrowController
    {
        [SerializeField] private float force;
        [SerializeField] private float forceUnderSpeed;
        
        private IRemoving _removing;
        private IGetterSpeed _getterSpeed;
        
        public void Init(IRemoving removing, IGetterSpeed getterSpeed)
        {
            _removing = removing;
            _getterSpeed = getterSpeed;
        }

        public void Throw()
        {
            if (!_removing.TryRemove(out var obj))
                return;
            if (!obj.TryGetComponent<IThrowing>(out var throwObj))
                throw new Exception($"Не получилось получить компонент {typeof(IThrowing)} у выбрасымаего объекта");
            throwObj.ThrowMe(transform.forward * (force + _getterSpeed.Speed * forceUnderSpeed));
        }
    }
}