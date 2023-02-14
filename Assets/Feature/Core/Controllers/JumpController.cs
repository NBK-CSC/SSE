using System;
using System.Collections;
using SSE.Core.Abstractions.Controllers;
using UnityEngine;

namespace SSE.Core.Controllers
{
    /// <summary>
    /// Контроллер прыжка
    /// </summary>
    [RequireComponent(typeof(GravityController), typeof(CharacterController))]
    public class JumpController : BaseInteractController, IJumping
    {
        [SerializeField] [Min(0)] private float jumpHeight = 1f;
        
        private CharacterController _characterController;
        private IGravitational _gravityController;
        private bool _isStarted = false;
        private Transform _transform;
        
        public override event Action<bool> OnInteracted;
        
        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _gravityController = GetComponent<IGravitational>();
            _transform = transform;
        }
        
        public void Jump()
        {
            if (!_gravityController.IsOnGround || _isStarted)
                return;
            _isStarted = true;
            StartCoroutine(ToStart());
        }
        
        private IEnumerator ToStart()
        {
            OnInteracted?.Invoke(true);
            _gravityController.Velocity = Mathf.Sqrt(jumpHeight * -2f * _gravityController.Gravity);
            while (_gravityController.Velocity > 0f)
            {
                var lastPositionY = _transform.position.y;
                _characterController.Move(_transform.up * (_gravityController.Velocity * Time.deltaTime));
                if (lastPositionY == _transform.position.y)
                    _gravityController.Velocity = 0f;

                yield return new WaitForSeconds(Time.deltaTime);
            }
            OnInteracted?.Invoke(false);
            _isStarted = false;
        }
    }
}