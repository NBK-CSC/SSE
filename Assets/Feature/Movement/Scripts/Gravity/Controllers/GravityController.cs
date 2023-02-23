using System;
using System.Threading.Tasks;
using SSE.Core.Abstractions.Behaviours;
using SSE.Core.Abstractions.Controllers;
using SSE.Movement.Gravity.Abstractions.Controllers;
using UnityEngine;

namespace SSE.Movement.Gravity.Controllers
{
    /// <summary>
    /// Контроллер гравитации
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class GravityController : BaseInteractController, IGravitational
    {
        [SerializeField] private float startVelocity = -2f;
        [SerializeField] private float gravity = 10f;
        
        private ISurfaceDetecting _detector;
        private CharacterController _characterController;
        
        private float _lastVelocity;
        private bool _isInit;
        
        public override event Action<bool> OnInteracted;
        
        public float Gravity => gravity;
        
        public float Velocity { get; set; }
        
        public void Init(CharacterController characterController, ISurfaceDetecting surfaceDownDetector)
        {
            _characterController = characterController;
            _detector = surfaceDownDetector;
            _isInit = true;
        }

        protected override async void OnEnable()
        {
            base.OnEnable();
            while (!_isInit)
                await Task.Yield();
            _detector.OnInteracted += SetGravity;
        }

        protected override async void OnDisable()
        {
            base.OnDisable();
            while (!_isInit)
                await Task.Yield();
            _detector.OnInteracted -= SetGravity;
        }

        private void Start()
        {
            Velocity = startVelocity;
        }

        private void Update()
        {
            if (!_detector.IsOnSurface)
                Fall();
        }
        
        private void SetGravity(bool state)
        {
            if (state && Velocity <= 0f)
                Velocity = startVelocity;
            OnInteracted?.Invoke(!_detector.IsOnSurface);
        }

        private void Fall()
        {
            Velocity += gravity * Time.deltaTime;
            _characterController.Move(transform.up * (Velocity * Time.deltaTime));
        }
    }
}