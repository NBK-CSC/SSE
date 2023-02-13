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
        
        private float _velocity;
        private int _countGroundChecker = 0;
        
        public override event Action<bool> OnInteracted;

        public bool IsOnGround => _countGroundChecker >= 1;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _detector = GetComponentInChildren<IGroundDetecting>();
        }

        private void OnEnable()
        {
            _detector.OnInteracted += SetGravity;
        }

        private void OnDisable()
        {
            _detector.OnInteracted -= SetGravity;
        }

        private void Start()
        {
            _velocity = startVelocity;
        }

        private void Update()
        {
            if (!IsOnGround)
                Fall();
        }
        
        private void SetGravity(bool state)
        {
            _countGroundChecker += state ? 1 : -1;
            if (state)
                _velocity = startVelocity;
            OnInteracted?.Invoke(!IsOnGround);
        }

        private void Fall()
        {
            _velocity -= gravity * Time.deltaTime;
            _characterController.Move(transform.up * _velocity);
        }
    }
}