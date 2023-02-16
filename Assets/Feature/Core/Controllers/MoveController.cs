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
        private Vector3 _direction;
        private float _currentSpeed;
        
        public override event Action<bool> OnInteracted;
        
        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }
        
        private void Start()
        {
            _currentSpeed = speed;
        }
        
        private void Update()
        {
            Move();
        }
        
        public void Interact(Vector3 direction)
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
            _characterController.Move(_direction * (_currentSpeed * Time.deltaTime));
        }
        
        public void AddBoost(float boost)
        {
            _currentSpeed -= boost;
        }
        
        public void RemoveBoost()
        {
            _currentSpeed = speed;
        }
    }
}