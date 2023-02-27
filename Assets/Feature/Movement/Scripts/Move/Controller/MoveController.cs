using System;
using SSE.Core.Abstractions.Behaviours;
using SSE.Core.Abstractions.Controllers;
using SSE.Core.Behaviours;
using SSE.Movement.Move.Abstractions.Controller;
using UnityEngine;

namespace SSE.Movement.Move.Controller
{
    /// <summary>
    /// Контроллер передвижения
    /// </summary>
    [RequireComponent(typeof(CharacterController))]
    public class MoveController : BaseInteractController, IMoving, ICanRestrict
    {
        [SerializeField] private float speed;
        
        private CharacterController _characterController;
        private Transform _transform;
        private Vector3 _direction;
        private float _currentSpeed;
        private float _boost = 1;
        private bool _isInit;

        public IRestricted RestrictProperty { get; } = new RestrictionProperty();

        public override event Action<bool> OnInteracted;
        
        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _transform = transform;
        }
        
        private void Start()
        {
            _currentSpeed = speed;
        }
        
        private void Update()
        {
            if (!RestrictProperty.IsRestrict)
                Move();
        }

        public void Init(CharacterController characterController)
        {
            _characterController = characterController;
        }
        
        public void Move(Vector3 direction)
        {
            if (_direction.Equals(direction))
                return;
            if(_direction.magnitude == 0)
                OnInteracted?.Invoke(true);
            _direction = direction;
            if(direction.magnitude == 0)
                OnInteracted?.Invoke(false);
        }
        
        private void Move()
        {
            _characterController.Move(
                (_transform.right * _direction.x + _transform.forward * _direction.y) 
                * (_currentSpeed * _boost * Time.deltaTime));
        }
        
        public void AddBoost(float boost)
        {
            _boost = boost;
        }
        
        public void RemoveBoost()
        {
            _boost = 1;
        }
    }
}