using System;
using SSE.Core.Abstractions.Behaviours;
using SSE.Core.Abstractions.Controllers;
using UnityEngine;

namespace SSE.Core.Controllers
{
    /// <summary>
    /// Контроллер гравитации
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class GravityController : BaseInteractController, IGravitational
    {
        [SerializeField] private float startVelocity = -2f;
        [SerializeField] private float gravity = 10f;
        
        private IGroundDetecting _detector;
        private CharacterController _characterController;
        
        private int _countGroundChecker = 0;
        private float _lastVelocity;
        
        public override event Action<bool> OnInteracted;

        public bool IsOnGround => _countGroundChecker >= 1;
        
        public float Gravity => gravity;
        
        public float Velocity { get; set; }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _detector = GetComponentInChildren<IGroundDetecting>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            _detector.OnInteracted += SetGravity;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _detector.OnInteracted -= SetGravity;
        }

        private void Start()
        {
            Velocity = startVelocity;
        }

        private void Update()
        {
            if (!IsOnGround)
                Fall();
        }
        
        private void SetGravity(bool state)
        {
            _countGroundChecker += state ? 1 : -1;
            if (state && Velocity <= 0f)
                Velocity = startVelocity;
            OnInteracted?.Invoke(!IsOnGround);
        }

        private void Fall()
        {
            Velocity += gravity * Time.deltaTime;
            _characterController.Move(transform.up * (Velocity * Time.deltaTime));
        }
    }
}