using System;
using System.Collections;
using SSE.Core.Abstractions.Behaviours;
using SSE.Core.Abstractions.Controllers;
using SSE.Core.Behaviours;
using UnityEngine;

namespace SSE.Core.Controllers
{
    /// <summary>
    /// Контроллер прыжка
    /// </summary>
    public class JumpController : BaseInteractController, IJumping, ICanRestrict
    {
        [SerializeField] [Min(0)] private float jumpHeight = 1f;
        
        private CharacterController _characterController;
        private ISurfaceDetecting _detector;
        private IGravitational _gravityController;
        private Transform _transform;
        private bool _isStarted = false;

        public IRestricted RestrictProperty { get; } = new RestrictionProperty();

        public override event Action<bool> OnInteracted;
        
        private void Awake()
        {
            _transform = transform;
        }

        public void Init(CharacterController characterController, IGravitational gravitateController, ISurfaceDetecting surfaceDownDetector)
        {
            _characterController = characterController;
            _gravityController = gravitateController;
            _detector = surfaceDownDetector;
        }

        public void Jump()
        {
            if (!_detector.IsOnSurface || RestrictProperty.IsRestrict || _isStarted)
                return;
            _isStarted = true;
            StartCoroutine(DelayStart());
        }
        
        private IEnumerator DelayStart()
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