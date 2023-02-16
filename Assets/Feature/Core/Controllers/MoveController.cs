using System;
using SSE.Core.Abstractions.Controllers;
using UnityEngine;

namespace SSE.Core.Controllers
{
    /// <summary>
    /// Контроллер передвижения
    /// </summary>
    [RequireComponent(typeof(CharacterController), typeof(GravityController))]
    public class MoveController : BaseInteractController, IMoving
    {
        [SerializeField] private float speed;
        
        private CharacterController _characterController;
        private Transform _transform;
        private Vector3 _direction;
        private float _currentSpeed;
        private float _boost = 1;
        
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
            Move();
        }

        public void Interact(Vector2 direction)
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